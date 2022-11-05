using System;
using System.Linq;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Utils;
using UnityEngine;

namespace GcpClient.Runtime.Places.Response
{
    /// <summary>
    /// GoogleMapの場所の情報
    /// </summary>
    public struct PlaceInfo
    {
        public BasicInfo Basic { get; }

        public PlaceInfo(BasicInfo basic) : this()
        {
            Basic = basic;
        }
    }

    public struct BasicInfo
    {
        public AddressComponent[] AddressComponents { get; }
        public string AdrAddress { get; }
        public BusinessStatus BusinessStatus { get; }
        public string FormattedAddress { get; }
        public Geometry Geometry { get; }
        public string IconUrl { get; }
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
            AddressComponents = addressComponents.Select(x => x.ToAddressInfo()).ToArray();
            AdrAddress = adrAddress;
            BusinessStatus = DtoHelper.BusinessStatusTable[businessStatus];
            FormattedAddress = formattedAddress;
            Geometry = geometry;
            IconUrl = icon;
            IconMaskBaseUri = iconMaskBaseUri;
            ColorUtility.TryParseHtmlString(iconBackGroundColor, out _iconBgColor);
            Name = name;
            Photos = photos.Select(x => x.ToPlacePhoto()).ToArray();
            PlaceId = placeId;
            PlusCode = plusCode;
            PlaceTypes = types.Select(x => DtoHelper.PlaceTypeTable[x]).ToArray();
            Url = url;
            UtcOffset = utcOffset;
            Vicinity = vicinity;
        }
    }

    /// <summary>
    /// 施設情報
    /// </summary>
    public struct FacilityInfo
    {
        public bool IsSupportedCurbsidePickup { get; }
        public bool IsOpenNow { get; }
        public SecondaryOpeningHoursType SecondaryOpeningHoursType { get; }
        public string[] WeekDayTexts { get; }
        public PlaceType[] PlaceTypes { get; }
    }

    public struct AddressComponent
    {
        public string LongName { get; }
        public string ShortName { get; }
        public ResponsePlaceType[] Types { get; }

        public AddressComponent(string longName, string shortName, ResponsePlaceType[] types)
        {
            LongName = longName;
            ShortName = shortName;
            Types = types;
        }
    }

    public struct PlaceOpeningHoursPeriodDetail
    {
        public DayOfWeek DayOfWeek { get; }
        public DateTime DateTime { get; }
        public bool IsTruncated { get; }

        public PlaceOpeningHoursPeriodDetail(DayOfWeek dayOfWeek, DateTime dateTime, bool isTruncated)
        {
            DayOfWeek = dayOfWeek;
            DateTime = dateTime;
            IsTruncated = isTruncated;
        }
    }
}