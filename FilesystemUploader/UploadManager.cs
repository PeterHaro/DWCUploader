using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json;
using System.Xml;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Text.Json.Serialization;

namespace FilesystemUploader;

public class UploadManager
{
    private const string StateFileName = "State.json";
    private readonly string _directoryToWatch;
    private readonly string _watchFilter;
    private ConcurrentDictionary<string, DateTime> _files = new ConcurrentDictionary<string, DateTime>();
    private PhysicalFileProvider? _fileProvider;
    private IChangeToken? _fileChangeToken;
    private bool _isRunning = false;
    //private Uploader _uploader = null;
    private FiwareUploader _fiwareUploader;
    private Transformer _transformer = new Transformer();

    public UploadManager(string directoryToWatch = "./", string watchFilter = "**/*.*", string remoteFiwareEndpoint = "", string fiwareAuthToken="")
    {
        _directoryToWatch = directoryToWatch;
        _watchFilter = watchFilter;
        AppDomain.CurrentDomain.ProcessExit += (s, e) => SerializeManagerState();
        
        AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly()).Unloading += context =>
        {
            SerializeManagerState();
        };
        
        Console.CancelKeyPress += (s, e) =>
        {
            SerializeManagerState();
            Environment.Exit(0);
        };
        DeserializeManagerState();

        if (!string.IsNullOrEmpty(remoteFiwareEndpoint) && !string.IsNullOrEmpty(fiwareAuthToken))
        {
            Console.WriteLine("Uploader should be intialized");
            //_uploader = new Uploader(remoteFiwareEndpoint, fiwareAuthToken);
            _fiwareUploader = new FiwareUploader(remoteFiwareEndpoint);
        }
        
        //Create backup folder
        Directory.CreateDirectory(Path.GetDirectoryName(directoryToWatch + "/backup/"));
        
        //check if the state file exists, if not create an empty file
        if(!File.Exists(StateFileName))
        {
            SerializeManagerState();
        }
    }

    public async Task AuthenticateWithRemote()
    {
        await _fiwareUploader.AuthenticateWithRemote();
    }
    
  /*  public async Task TestConnectionToFiware()
    {
        if (_uploader == null)
        {
            Console.WriteLine("The uploader has not been initalized correctly. Aborting");
            return;
        }
        await _uploader.PerformGetRequest("v2/enteties");
        Console.WriteLine("Done");
    }*/

  /*  public async Task TestPostWaterObserved()
    {
        if (_uploader == null)
        {
            Console.WriteLine("The uploader has not been initalized correctly. Aborting");
            return;
        }
        
        // Select random water observed file (this is just for testing)
        var jsonRequest = _transformer.TransformToWaterObservedInMemory("./files/EDEN.csv");
        await _uploader.PerformPostRequest(jsonRequest);
        Console.WriteLine("Done");
    }*/
    
    public async void BeginTheWatch()
    {
        _isRunning = true;
        _fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), _directoryToWatch));
        await WatchForFileChanges();
    }

    public void EndTheWatch()
    {
        _isRunning = false;
        _fileProvider = null;
        _fileChangeToken = null;
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    private async void SerializeManagerState()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        await using FileStream createStream = File.Create(StateFileName);
        await JsonSerializer.SerializeAsync(createStream, _files, options);
        await createStream.DisposeAsync();
    }

    private async void DeserializeManagerState()
    {
        var json = await File.ReadAllTextAsync(StateFileName);
        _files = JsonSerializer.Deserialize<ConcurrentDictionary<string, DateTime>>(json) ?? new ConcurrentDictionary<string, DateTime>();
    }
    
    private List<string> DetectFilesMarkedForDeletion(IEnumerable<string> files)
    {
        List<string> retval = new List<string>();
        foreach (var file in files)
        {
            if (!_files.ContainsKey(file))
            {
                //Detected deleted file
                //Send delete request
            }
        }
        
        
        return retval;
    }

    public async Task TestFinalModel(string inputFile)
    {
        var edenData = _transformer.TransformToFinalModel(inputFile);
        var json = JsonSerializer.Serialize(edenData);
        await File.WriteAllTextAsync("final_model_test.json", json);
        Console.WriteLine(json);
    }
    
    
    private async Task WatchForFileChanges()
    {
        IEnumerable<string> files = Directory.EnumerateFiles(_directoryToWatch, "*.*", SearchOption.TopDirectoryOnly);
        var enumerable = files.ToList();
        foreach (var file in enumerable)
        {
            Console.WriteLine(file);
        }
        foreach (string file in enumerable)
        {
            if (_files.TryGetValue(file, out DateTime existingTime))
            {
                if (File.GetLastWriteTime(file) > existingTime)
                {
                    Console.WriteLine($"{file} should be patched");
                }
                _files.TryUpdate(file, File.GetLastWriteTime(file), existingTime);
            }
            else
            {
                if (File.Exists(file)) // New file added to system. I.E should post
                {
                    Console.WriteLine($"Detected a new file {file}");
                    if (_fiwareUploader != null)
                    {
                        Console.WriteLine("Uploader is not null");
                        
                        // IGNORE OUR OWN GENERATED FILES
                        if (Path.GetFileName(file).StartsWith("DWC_EDEN_"))
                        {
                            // IGnore this file
                            Console.WriteLine("Found our heartbeat");
                            continue;
                        }
                        
                        var patches = (_transformer.TransformToFinalModel(file));
                        foreach (var patchable in patches)
                        {
                            await _fiwareUploader.PerformPatch(patchable);
                        }
                        //Copy file to backup
                        File.Copy(file, _directoryToWatch+"/backup/"+Path.GetFileName(file));
                        Console.WriteLine($"copied file to {_directoryToWatch+"/backup/"+Path.GetFileName(file)}");
                        //Delete file
                        File.Delete(file);
                        Console.WriteLine($"Should have deleted file: {file}");
                        
                    }
                    _files.TryAdd(file, File.GetLastWriteTime(file));
                }
            }
        }
        
        //Detect deleted files
        // IF we need to support it here we should handle deleted file(s)

        _fileChangeToken = _fileProvider?.Watch(_watchFilter);
        _fileChangeToken?.RegisterChangeCallback(Notify, default);
    }

    private void Notify(object state)
    {
        Console.WriteLine(state);
        WatchForFileChanges();
    }
}