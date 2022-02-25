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

    public UploadManager(string directoryToWatch = "./", string watchFilter = "**/*.*")
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
    }

    public void BeginTheWatch()
    {
        _isRunning = true;
        _fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), _directoryToWatch));
        WatchForFileChanges();
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
        var json = File.ReadAllText(StateFileName);
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
    
    private void WatchForFileChanges()
    {
        IEnumerable<string> files = Directory.EnumerateFiles(_directoryToWatch, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
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