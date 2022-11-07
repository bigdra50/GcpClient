using System.Linq;
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

        public PlaceInfo(
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
            string vicinity) : this()
        {
            Basic = new BasicInfo(
                addressComponents,
                adrAddress,
                businessStatus,
                formattedAddress,
                geometry,
                icon,
                iconMaskBaseUri,
                iconBackGroundColor,
                name,
                photos,
                placeId,
                plusCode,
                types,
                url,
                utcOffset,
                vicinity);
        }

        public PlaceInfo(BasicInfo basicInfo) : this()
        {
            Basic = basicInfo;
        }

        public PlaceInfo(BasicInfo basicInfo,
            PlaceOpeningHoursDto currentOpeningHours,
            string formattedPhoneNumber,
            string internationalPhoneNumber,
            PlaceOpeningHoursDto openingHours,
            PlaceOpeningHoursDto secondaryOpeningHours,
            string website) : this(basicInfo)
        {
            Contact = new ContactInfo(
                currentOpeningHours,
                formattedPhoneNumber,
                internationalPhoneNumber,
                openingHours,
                secondaryOpeningHours,
                website);
        }

        public PlaceInfo RegisterContactInfo(
            PlaceOpeningHoursDto currentOpeningHours,
            string formattedPhoneNumber,
            string internationalPhoneNumber,
            PlaceOpeningHoursDto openingHours,
            PlaceOpeningHoursDto secondaryOpeningHours,
            string website) => new(
            Basic,
            currentOpeningHours,
            formattedPhoneNumber,
            internationalPhoneNumber,
            openingHours,
            secondaryOpeningHours,
            website);


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
            Status = DtoHelper.PlacesSearchStatusTable[status];
            ErrorMessages = errorMessages;
            HtmlAttributions = htmlAttributions;
            InfoMessages = infoMessages;
            NextPageToken = nextPageToken;
        }
    }
}