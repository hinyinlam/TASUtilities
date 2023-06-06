using System.Net;

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
    public NetworkSpec[] Networks { get; set; }
}

public class NetworkSpec
{
    public string Name { get; set; }
    public string Type { get; set; }
    public SubnetSpec[] Subnets { get; set; }
}

public class SubnetSpec
{
    public IPAddress Netmask { get; set; }
    public IPAddress[] Dns { get; set; }
    public IPAddress Gateway { get; set; }
    public RangeSpec Range { get; set; }
    public Dictionary<string, string> CloudProperties { get; set; }
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
    public string[] azs;
    public int instances;
    public JobSpec[] jobs;
    public string Lifecycle;
    public string Name;
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