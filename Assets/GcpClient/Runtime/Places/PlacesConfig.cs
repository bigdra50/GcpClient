using GcpClient.Runtime.Places.Details;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Search.FindPlace;
using GcpClient.Runtime.Places.Search.NearbySearch;
using GcpClient.Runtime.Places.Search.TextSearch;
using UnityEngine;

namespace GcpClient.Runtime.Places
{
    [CreateAssetMenu(fileName = "PlacesConfig", menuName = "Places/Config", order = 0)]
    public class PlacesConfig : ScriptableObject
    {
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

        public PhotoConfig PhotoConfig => _photoConfig;
        public DetailsConfig DetailsConfig => _detailsConfig;
        public NearbySearchConfig NearbySearchConfig => _nearbySearchConfig;
        public FindPlaceConfig FindPlaceConfig => _findPlaceConfig;
        public TextSearchConfig TextSearchConfig => _textSearchConfig;

        [SerializeField] private string _apiKeyIos;
        [SerializeField] private string _apiKeyAndroid;
        [SerializeField] private string _apiKeyAny;

        [SerializeField] private PhotoConfig _photoConfig;
        [SerializeField] private DetailsConfig _detailsConfig;
        [SerializeField] private NearbySearchConfig _nearbySearchConfig;
        [SerializeField] private FindPlaceConfig _findPlaceConfig;
        [SerializeField] private TextSearchConfig _textSearchConfig;
    }
}