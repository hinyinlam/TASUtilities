using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DeploymentManifestParser;

public class BoshManifestDeserialization
{
    public static BoshManifest GetDeserializedBoshManifest(string filePath)
    {
        using var yamlRead = new StreamReader(filePath);

        var deserializer = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .WithTypeConverter(new RangeSpecTypeConverter())
            .Build();

        var boshManifest = deserializer.Deserialize<BoshManifest>(yamlRead);
        return boshManifest;
    }
}