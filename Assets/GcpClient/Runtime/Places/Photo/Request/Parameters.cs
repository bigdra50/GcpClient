namespace GcpClient.Runtime.Places.Photo.Request
{
    public class PhotoReference : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public PhotoReference(string value)
        {
            Key = "photo_reference";
            Value = value;
        }
    }

    public class MaxHeight : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public MaxHeight(int value)
        {
            Key = "maxheight";
            Value = value.ToString();
        }
    }
    public class MaxWidth : IParameter
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