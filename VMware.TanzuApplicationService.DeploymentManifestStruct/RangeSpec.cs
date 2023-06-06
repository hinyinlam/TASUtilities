using System.Net;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

public class RangeSpec
{
    public int mask; //eg  /24
    public IPAddress subnet; //eg 192.168.1.0
}

public class RangeSpecTypeConverter : IYamlTypeConverter
{
    private static readonly Type _RangeSpecType = typeof(RangeSpec);

    public bool Accepts(Type type)
    {
        return type == _RangeSpecType;
    }

    public object? ReadYaml(IParser parser, Type type)
    {
        var parserCurrent = parser.Current;
        if (parserCurrent.GetType().Name == "Scalar")
        {
            var parserMoved = parser.MoveNext(); //Parser will complain that the current token hasn't moved
            var current = (Scalar)parserCurrent;
            var strings = current.Value.Split("/");
            if (strings.Length != 2)
            {
                return null;
            }

            return new RangeSpec
            {
                subnet = IPAddress.Parse(strings[0]),
                mask = int.Parse(strings[1]),
            };
        }

        return null;
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        throw new NotImplementedException();
    }
}