namespace GcpClient.Runtime.Places.Photo.Request
{
    public struct PhotoReference : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public PhotoReference(string value)
        {
            Key = "photo_reference";
            Value = value;
        }
    }

    public struct MaxHeight : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public MaxHeight(int value)
        {
            Key = "maxheight";
            Value = value.ToString();
        }
    }
    public struct MaxWidth : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public MaxWidth(int value)
        {
            Key = "maxwidth";
            Value = value.ToString();
        }
    }
}