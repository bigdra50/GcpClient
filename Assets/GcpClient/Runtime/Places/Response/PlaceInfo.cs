using System;
using System.Linq;
using GcpClient.Runtime.Places.Field;
using GcpClient.Runtime.Places.Utils;

namespace GcpClient.Runtime.Places.Response
{
    /// <summary>
    /// GoogleMapの場所の情報
    /// </summary>
    public struct PlaceInfo
    {
        public BasicInfo Basic { get; }
        public ContactInfo Contact { get; }
        public AtmosphereInfo AtmosphereInfo { get; }

        public PlaceInfo(BasicInfo basicInfo) : this()
        {
            Basic = basicInfo;
        }

        public PlaceInfo(BasicInfo basicInfo, ContactInfo contactInfo) : this(basicInfo)
        {
            Contact = contactInfo;
        }

        public PlaceInfo(BasicInfo basicInfo, ContactInfo contactInfo, AtmosphereInfo atmosphereInfo): this(basicInfo, contactInfo)
        {
            AtmosphereInfo = atmosphereInfo;
        }

        public PlaceInfo(BasicInfo basicInfo, AtmosphereInfo atmosphereInfo): this(basicInfo)
        {
            AtmosphereInfo = atmosphereInfo;
        }

        public PlaceInfo(BasicInfo basicInfo,
            string formattedPhoneNumber,
            string internationalPhoneNumber,
            PlaceOpeningHoursDto openingHours,
            PlaceOpeningHoursDto currentOpeningHours,
            PlaceOpeningHoursDto secondaryOpeningHours,
            string website) : this(basicInfo)
        {
            Contact = new ContactInfo(
                formattedPhoneNumber: formattedPhoneNumber,
                internationalPhoneNumber: internationalPhoneNumber,
                openingHours: openingHours,
                currentOpeningHours: currentOpeningHours,
                secondaryOpeningHours: secondaryOpeningHours,
                website: website);
        }


        public override string ToString()
        {
            return $"Basic Info: \n" +
                   $"Name: {Basic.Name}\n" +
                   $"Business Status: {Basic.BusinessStatus.ToString()}\n" +
                   $"Adr Address: {Basic.AdrAddress}\n" +
                   $"Formatted Address: {Basic.FormattedAddress}\n" +
                   $"Url: {Basic.Url}\n" +
                   $"Utc Offset: {Basic.UtcOffset}\n" +
                   $"Vicinity: {Basic.Vicinity}\n" +
                   $"PlaceID: {Basic.PlaceId}\n" +
                   $"Icon URL: {Basic.IconUrl}\n" +
                   $"Icon BG Color: {Basic.IconBgColor}\n" +
                   $"IconMaskBaseUrl: {Basic.IconMaskBaseUri}" +
                   $"Geometry: \n" +
                   $"-- Location: ({Basic.Geometry.location.lat},{Basic.Geometry.location.lng})\n" +
                   $"-- Viewport: \n" +
                   $"---- North East: ({Basic.Geometry.viewport.northeast.lat}, {Basic.Geometry.viewport.northeast.lng})\n" +
                   $"---- South West: ({Basic.Geometry.viewport.southwest.lat}, {Basic.Geometry.viewport.southwest.lng}\n" +
                   $"PlusCode:\n" +
                   $"-- global code: {Basic.PlusCode.global_code}\n" +
                   $"-- compound code: {Basic.PlusCode.compound_code}\n" +
                   $"Place Types: \n{Basic.PlaceTypes.Aggregate("", (current, basicPlaceType) => current + $"- {basicPlaceType}\n")}";
        }
    }

    public struct PlaceSearchMeta
    {
        public PlacesSearchStatus Status { get; }
        public string ErrorMessages { get; }
        public string[] HtmlAttributions { get; }
        public string[] InfoMessages { get; }
        public string NextPageToken { get; }

        public PlaceSearchMeta(string status, string errorMessages, string[] htmlAttributions, string[] infoMessages, string nextPageToken)
        {
            Status = DtoHelper.PlacesSearchStatusMap[status];
            ErrorMessages = errorMessages;
            HtmlAttributions = htmlAttributions;
            InfoMessages = infoMessages;
            NextPageToken = nextPageToken;
        }
    }

    public struct PlaceDetailsMeta
    {
        public PlaceDetailsStatus Status { get; }
        public string[] HtmlAttributions { get; }
        public string[] InfoMessages { get; }

        public PlaceDetailsMeta(string status, string[] htmlAttributions, string[] infoMessages)
        {
            Status = status switch
            {
                "OK" => PlaceDetailsStatus.Ok,
                "ZERO_RESULTS" => PlaceDetailsStatus.ZeroResults,
                "NOT_FOUND" => PlaceDetailsStatus.NotFound,
                "INVALID_REQUEST" => PlaceDetailsStatus.InvalidRequest,
                "OVER_QUERY_LIMIT" => PlaceDetailsStatus.OverQueryLimit,
                "REQUEST_DENIED" => PlaceDetailsStatus.RequestDenied,
                "UNKNOWN_ERROR" => PlaceDetailsStatus.UnknownError,
            };
            HtmlAttributions = htmlAttributions;
            InfoMessages = infoMessages;
        }
    }
}