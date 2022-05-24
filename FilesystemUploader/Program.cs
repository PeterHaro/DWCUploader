using System.Transactions;
using FilesystemUploader;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

//_TEST
Transformer transformer = new Transformer();
transformer.TestTransformation();
//__END_TEST_
// ADD ENDPOINT
// ADD AUTH TOKEN BEFORE TESTING
UploadManager manager = new UploadManager("./test", "**/*.*","", "");
await manager.TestConnectionToFiware();
await manager.TestPostWaterObserved();

manager.BeginTheWatch();
Console.ReadKey(false);