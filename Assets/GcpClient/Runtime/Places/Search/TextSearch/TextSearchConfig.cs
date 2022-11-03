using UnityEngine;

namespace GcpClient.Runtime.Places.Search.TextSearch
{
    [CreateAssetMenu(fileName = "TextSearchConfig", menuName = "Places/Search/TextSearch/Config", order = 1)]
    public class TextSearchConfig : ScriptableObject
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/output";
        [SerializeField] private PlacesConfig _placesConfig;
    }
}