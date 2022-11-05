namespace GcpClient.Runtime.Places.Response
{
    /// <summary>
    /// 地理的な情報
    /// </summary>
    public struct GeographicInfo
    {
        public AddressComponent[] AddressComponents { get; }
        public string adr { get; }
    }
}