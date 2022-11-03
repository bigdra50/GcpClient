using UnityEngine;

namespace GcpClient.Runtime.Places.Search.FindPlace
{
    [CreateAssetMenu(fileName = "FindPlaceConfig", menuName = "Places/Search/FindPlace/Config", order = 1)]
    public class FindPlaceConfig : ScriptableObject
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/findplacefromtext/output";
        [SerializeField] private PlacesConfig _placesConfig;
    }
}