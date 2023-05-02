// See https://aka.ms/new-console-template for more information

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var path = Environment.GetEnvironmentVariable("BOSH_MANIFEST_FILE_PATH");
if (path == null || path=="")
{
    throw new Exception("Missing environment variable BOSH_MANIFEST_FILE_PATH");
}

var file = new FileInfo(path);
var tileName = file.Directory.Name;
using var yamlRead = new StreamReader(path);

var deserializer = new DeserializerBuilder()
    .IgnoreUnmatchedProperties()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var myBoshManifest = deserializer.Deserialize<BoshManifest>(yamlRead);
Console.WriteLine($"------List of Instance Group and Number of instances in {tileName}----");
foreach (var ig in myBoshManifest.InstanceGroups)
{
    Console.WriteLine($"{ig.Name,-30}: {ig.instances,-3}");
}

public class BoshManifest
{
    public string Name;

    // public ReleaseSpec[] Releases { get; set; }
    // public StemcellSpec[] Stemcells { get; set; }
    public InstanceGroupSpec[] InstanceGroups { get; set; }
    // public UpdateSpec[] update { get; set; }
    // public AddonSpec[] AddonSpecs { get; set; }
    // public VarableSpec[] variables { get; set; }
    // public MemoSpec Memo { get; set; }
}

public class MemoSpec
{
}

public class VarableSpec
{
}

public class AddonSpec
{
}

public class UpdateSpec
{
}

public class InstanceGroupSpec
{
    public string Name;
    public string[] azs;
    public int instances;
    public string Lifecycle;
    public JobSpec[] jobs;
}

public class JobSpec
{
    public string Name;

    public string Release;
    // public Dictionary<string, ConsumeSpec>? Consumes;
    // public Dictionary<string, ProvideSpec>? Provides;
    // public string Properties;
}

public class ProvideSpec
{
}

public class ConsumeSpec
{
}

public class StemcellSpec
{
}

public class ReleaseSpec
{
}