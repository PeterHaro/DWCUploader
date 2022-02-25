using System.Transactions;
using FilesystemUploader;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

//_TEST
Transformer transformer = new Transformer();
transformer.TestTransformation();
//__END_TEST_

UploadManager manager = new UploadManager("./test");
manager.BeginTheWatch();
Console.ReadKey(false);