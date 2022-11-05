using UnityEngine;

namespace GcpClient.Runtime.Places.Search.NearbySearch
{
    [CreateAssetMenu(fileName = "NearbySearchConfig", menuName = "Places/Search/NearbySearch/Config", order = 1)]
    public class NearbySearchConfig : ScriptableObject
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
    }
}