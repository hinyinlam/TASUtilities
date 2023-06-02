// See https://aka.ms/new-console-template for more information

using DeploymentManifestParser;

var path = Environment.GetEnvironmentVariable("BOSH_MANIFEST_FILE_PATH");
if (path == null || path == "")
{
    throw new Exception("Missing environment variable BOSH_MANIFEST_FILE_PATH");
}

var fileInfo = new FileInfo(path);
var tileName = fileInfo.Directory.Name;


var myBoshManifest = BoshManifestDeserialization.GetDeserializedBoshManifest(path);
Console.WriteLine($"------List of Instance Group and Number of instances in {tileName}----");
foreach (var ig in myBoshManifest.InstanceGroups)
{
    Console.WriteLine($"{ig.Name,-30}: {ig.instances,-3}");
}

foreach (var keypair in myBoshManifest.Networks[0].Subnets[0].CloudProperties)
{
    Console.WriteLine($"{keypair.Key}: {keypair.Value}");
}

