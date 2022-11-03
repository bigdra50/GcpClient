using UnityEngine;

namespace GcpClient.Runtime.Places.Photo
{
    [CreateAssetMenu(fileName = "PhotoConfig", menuName = "Places/Photo/Config", order = 3)]
    public class PhotoConfig : ScriptableObject
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/photo";
        public float TimeoutSec => _timeoutSec;
        [SerializeField] private PlacesConfig _placesConfig;
        [SerializeField] private float _timeoutSec = 5f;
        
    }
}