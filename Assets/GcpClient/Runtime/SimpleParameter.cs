using GcpClient.Runtime;

namespace GcpClient.GcpClient.Runtime
{
    public class SimpleParameter : IParameter
    {
        public string Key => _key;
        public string Value => _value;
        private readonly string _key;
        private readonly string _value;

        public SimpleParameter(string key, string value)
        {
            _key = key;
            _value = value;
        }
    }
}