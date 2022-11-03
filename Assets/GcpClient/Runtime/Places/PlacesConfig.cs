using UnityEditor;
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

        [SerializeField] private string _apiKeyIos;
        [SerializeField] private string _apiKeyAndroid;
        [SerializeField] private string _apiKeyAny;
    }
}