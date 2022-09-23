using System.Timers;
using System.Transactions;
using FilesystemUploader;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

//_TEST
int sequenceNumber = 0;
string directoryToWatch = "/eden/eden/upload";
string backupDirectory = "/backup";
//Transformer transformer = new Transformer();
//transformer.TestTransformation();
//__END_TEST_
// ADD ENDPOINT
// ADD AUTH TOKEN BEFORE TESTING
Console.WriteLine($"I am watching: {Path.GetFullPath(directoryToWatch)}");
UploadManager manager = new UploadManager(directoryToWatch, "**/*.*","https://c-broker.xyz/", "Bearer 06ce3ad0dcf97b09ef02c2d1cf009857cfcaf1b1");
System.Timers.Timer timer = new System.Timers.Timer(60000);
timer.Elapsed += SendHeartbeatToEden!;
timer.AutoReset = true;
timer.Enabled = true;
timer.Start();


//await manager.AuthenticateWithRemote();
//await manager.TestConnectionToFiware();
//await manager.TestPostWaterObserved();

//await manager.AuthenticateWithRemote();
//await manager.TestFinalModel("files/eden_production/EDEN_DWC_20220922_105533.csv");



manager.BeginTheWatch();
Console.ReadKey(false);


async void SendHeartbeatToEden(Object source, ElapsedEventArgs e)
{
        Console.WriteLine("Sending heartbeat");
        var timestamp = DateTime.Now;
        var filename = $"DWC_EDEN_{timestamp.ToString("yyyyMMdd_HHmmss")}.csv";
        var fileContents = $"DWC_SYST_SL;{timestamp.ToString("yyyy/MM/dd HH:mm:ss")};{++sequenceNumber % 9999},000;0";

        await using StreamWriter file = new(directoryToWatch + "/" +filename, append: false);
        await file.WriteAsync(fileContents);
}