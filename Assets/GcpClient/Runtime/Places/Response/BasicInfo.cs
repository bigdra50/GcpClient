using System.Linq;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Utils;
using UnityEngine;

namespace GcpClient.Runtime.Places.Response
{
    public struct BasicInfo
    {
        public AddressComponent[] AddressComponents { get; }
        public string AdrAddress { get; }
        public BusinessStatus BusinessStatus => _businessStatus;
        private readonly BusinessStatus _businessStatus;
        public string FormattedAddress { get; }
        public Geometry Geometry { get; }
        public string IconUrl { get; }
        public Color IconBgColor => _iconBgColor;
        private readonly Color _iconBgColor;
        public string IconMaskBaseUri { get; }
        public string Name { get; }
        public PlacePhoto[] Photos { get; }
        public string PlaceId { get; }
        public PlusCodeDto PlusCode { get; }
        public PlaceType[] PlaceTypes { get; }
        public string Url { get; }
        public int UtcOffset { get; }
        public string Vicinity { get; }

        public BasicInfo(
            AddressComponentDto[] addressComponents,
            string adrAddress,
            string businessStatus,
            string formattedAddress,
            Geometry geometry,
            string icon,
            string iconMaskBaseUri,
            string iconBackGroundColor,
            string name,
            PlacePhotoDto[] photos,
            string placeId,
            PlusCodeDto plusCode,
            string[] types,
            string url,
            int utcOffset,
            string vicinity)
        {
            AddressComponents = addressComponents?.Select(x => x.ToAddressInfo()).ToArray();
            AdrAddress = adrAddress;
            _businessStatus = BusinessStatus.Empty;
            if (businessStatus != null)
            {
                DtoHelper.BusinessStatusTable.TryGetValue(businessStatus, out _businessStatus);
            }


            FormattedAddress = formattedAddress;
            Geometry = geometry;
            IconUrl = icon;
            IconMaskBaseUri = iconMaskBaseUri;
            ColorUtility.TryParseHtmlString(iconBackGroundColor, out _iconBgColor);
            Name = name;
            Photos = photos?.Select(x => x.ToPlacePhoto()).ToArray();
            PlaceId = placeId;
            PlusCode = plusCode;
            PlaceTypes = types?
                .Select(x => (DtoHelper.PlaceTypeMap.TryGetValue(x, out var placeType), placeType))
                .Where(x => x.Item1)
                .Select(x => x.placeType)
                .ToArray();
            Url = url;
            UtcOffset = utcOffset;
            Vicinity = vicinity;
        }
    }

    public struct AddressComponent
    {
        public string LongName { get; }
        public string ShortName { get; }
        public PlaceTypeTable2[] Types { get; }

        public AddressComponent(string longName, string shortName, PlaceTypeTable2[] types)
        {
            LongName = longName;
            ShortName = shortName;
            Types = types;
        }
    }
}