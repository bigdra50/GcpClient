using System;

namespace GcpClient.Runtime.Places.Field
{
    [Flags]
    public enum BasicCategory
    {
        None = 0,
        AddressComponent = 1 << 0,
        AdrAddress = 1 << 1,
        BusinessStatus = 1 << 2,
        FormattedAddress = 1 << 3,
        Geometry = 1 << 4,
        Icon = 1 << 5,
        IconMaskBaseUri = 1 << 6,
        IconBackgroundColor = 1 << 7,
        Name = 1 << 8,
        PermanentlyClosed = 1 << 9,
        Photo = 1 << 10,
        PlaceId = 1 << 11,
        PlusCode = 1 << 12,
        Type = 1 << 13,
        Url = 1 << 14,
        UtcOffset = 1 << 15,
        Vicinity = 1 << 16,
    }

    [Flags]
    public enum ContactCategory
    {
        None = 0,
        CurrentOpeningHours = 1 << 0,
        FormattedPhoneNumber = 1 << 1,
        InternationalPhoneNumber = 1 << 2,
        OpeningHours = 1 << 3,
        SecondaryOpeningHours = 1 << 4,
        Website = 1 << 5,
    }

    [Flags]
    public enum AtmosphereCategory
    {
        None = 0,
        CurbsidePickup = 1 << 0,
        Delivery = 1 << 1,
        DineIn = 1 << 2,
        EditorialSummary = 1 << 3,
        PriceLevel = 1 << 4,
        Rating = 1 << 5,
        Reviews = 1 << 6,
        Takeout = 1 << 7,
        UserRatingsTotal = 1 << 8,
    }

    public static class FieldCategoryExtensions
    {
        public static bool HasBitFlag(this BasicCategory value, BasicCategory flag) => (value & flag) == flag;
        public static bool HasBitFlag(this ContactCategory value, ContactCategory flag) => (value & flag) == flag;
        public static bool HasBitFlag(this AtmosphereCategory value, AtmosphereCategory flag) => (value & flag) == flag;

        public static string CategoryToString(this BasicCategory category) => category switch
        {
            BasicCategory.None => "",
            BasicCategory.AddressComponent => "address_component",
            BasicCategory.AdrAddress => "adr_address",
            BasicCategory.BusinessStatus => "business_status",
            BasicCategory.FormattedAddress => "formatted_address",
            BasicCategory.Geometry => "geometry",
            BasicCategory.Icon => "icon",
            BasicCategory.IconMaskBaseUri => "icon_mask_base_uri",
            BasicCategory.IconBackgroundColor => "icon_background_color",
            BasicCategory.Name => "name",
            BasicCategory.PermanentlyClosed => "permanently_closed",
            BasicCategory.Photo => "photo",
            BasicCategory.PlaceId => "place_id",
            BasicCategory.PlusCode => "plus_code",
            BasicCategory.Type => "type",
            BasicCategory.Url => "url",
            BasicCategory.UtcOffset => "utc_offset",
            BasicCategory.Vicinity => "vicinity",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };

        public static string CategoryToString(ContactCategory category) => category switch
        {
            ContactCategory.None => "",
            ContactCategory.CurrentOpeningHours => "current_opening_hours",
            ContactCategory.FormattedPhoneNumber => "formatted_phone_number",
            ContactCategory.InternationalPhoneNumber => "international_phone_number",
            ContactCategory.OpeningHours => "opening_hours",
            ContactCategory.SecondaryOpeningHours => "secondary_opening_hours",
            ContactCategory.Website => "website",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };

        public static string CategoryToString(AtmosphereCategory category) => category switch
        {
            AtmosphereCategory.None => "",
            AtmosphereCategory.CurbsidePickup => "curbside_pickup",
            AtmosphereCategory.Delivery => "delivery",
            AtmosphereCategory.DineIn => "dine_in",
            AtmosphereCategory.EditorialSummary => "editorial_summary",
            AtmosphereCategory.PriceLevel => "price_level",
            AtmosphereCategory.Rating => "rating",
            AtmosphereCategory.Reviews => "reviews",
            AtmosphereCategory.Takeout => "takeout",
            AtmosphereCategory.UserRatingsTotal => "user_ratings_total",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
}