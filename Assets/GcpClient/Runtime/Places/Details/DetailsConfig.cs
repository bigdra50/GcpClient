using UnityEngine;

namespace GcpClient.Runtime.Places.Details
{
    [CreateAssetMenu(fileName = "PlaceDetailConfig", menuName = "Places/Details/Config", order = 2)]
    public class DetailsConfig : ScriptableObject
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/details/output";
        [SerializeField] private PlacesConfig _placesConfig;
    }
}