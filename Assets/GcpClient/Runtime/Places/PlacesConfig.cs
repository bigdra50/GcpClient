using UnityEngine;

namespace GcpClient.Runtime.Places
{
    [CreateAssetMenu(fileName = "PlacesConfig", menuName = "Places/Config", order = 0)]
    public class PlacesConfig : ScriptableObject
    {
        public const string PhotoUrl = "https://maps.googleapis.com/maps/api/place/photo";

        public const string DetailsUrl = "https://maps.googleapis.com/maps/api/place/details/json";
        public const string NearbySearchUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
        public const string TextSearchUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json";
        public const string FindPlaceUrl = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";
        
        
        public string ApiKey
        {
            get
            {
#if UNITY_ANDROID
                return _apiKeyAndroid;
#elif UNITY_IOS
                return _apiKeyIos;
#endif
                return _apiKeyAny;
            }
        }

        public float DefaultTimeoutSec => _defaultTimeoutSec;
        
        [SerializeField] private string _apiKeyIos;
        [SerializeField] private string _apiKeyAndroid;
        [SerializeField] private string _apiKeyAny;
        [SerializeField] private float _defaultTimeoutSec = 5f;
    }
}