using System;
using System.Collections.Generic;
using System.Linq;
using GcpClient.Runtime.Places.Field;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Utils;

namespace GcpClient.Runtime.Places.Response
{
    [Serializable]
    public struct PlacesNearbySearchResponseDto
    {
        public string[] html_attributions;
        public PlaceDto[] results;
        public string status;
        public string error_message;
        public string[] info_messages;
        public string next_page_token;

        public (PlaceSearchMeta meta, List<PlaceInfo> places) ToPlaceInfo()
        {
            var meta = new PlaceSearchMeta(status, error_message, html_attributions, info_messages, next_page_token);
            var placeInfo = results.Select(x => x.ToPlaceInfo()).ToList();
            return (meta, placeInfo);
        }
    }

    [Serializable]
    public struct PlaceDetailsResponse
    {
        public string[] html_attributions;
        public PlaceDto result;
        public string status;
        public string[] info_messages;

        public (PlaceDetailsMeta meta, PlaceInfo place) ToPlaceInfo()
        {
            var meta = new PlaceDetailsMeta(status, html_attributions, info_messages);
            var place = result.ToPlaceInfo();
            return (meta, place);
        }
    }

    [Serializable]
    public struct PlaceDto
    {
        public AddressComponentDto[] address_components;
        public string adr_address;
        public string business_status;
        public bool curbside_pickup;
        public PlaceOpeningHoursDto current_opening_hours;
        public bool delivery;
        public bool dine_in;
        public PlaceEditorialSummary editorial_summary;
        public string formatted_address;
        public string formatted_phone_number;
        public Geometry geometry;
        public string icon;
        public string icon_background_color;
        public string icon_mask_base_uri;
        public string international_phone_number;
        public string name;
        public PlaceOpeningHoursDto opening_hours;
        public PlacePhotoDto[] photos;
        public string place_id;
        public PlusCodeDto plus_code;
        public int price_level;
        public double rating;
        public PlaceReview[] reviews;
        public PlaceOpeningHoursDto secondary_opening_hours;
        public bool takeout;
        public string[] types;
        public string url;
        public int user_ratings_total;
        public int utc_offset;
        public string vicinity;
        public string website;

        public PlaceInfo ToPlaceInfo() => new(
            new BasicInfo(
                address_components,
                adr_address,
                business_status,
                formatted_address,
                geometry,
                icon,
                icon_mask_base_uri,
                icon_background_color,
                name,
                photos,
                place_id,
                plus_code,
                types,
                url,
                utc_offset,
                vicinity),
            new ContactInfo(
                formatted_phone_number,
                international_phone_number,
                opening_hours,
                current_opening_hours,
                secondary_opening_hours,
                website),
            new AtmosphereInfo(
                curbside_pickup,
                delivery,
                dine_in,
                editorial_summary,
                price_level,
                rating,
                reviews,
                takeout,
                user_ratings_total));
    }

    [Serializable]
    public struct AddressComponentDto
    {
        public string long_name;
        public string short_name;
        public string[] types;

        public AddressComponent ToAddressInfo() =>
            new(long_name, short_name, types.Select(x =>
                DtoHelper.PlaceTypeTable2Map[x]).ToArray());
    }

    [Serializable]
    public struct PlaceEditorialSummary
    {
        public string language;
        public string overview;
    }

    [Serializable]
    public struct Geometry
    {
        public LatLngLiteral location;
        public Bounds viewport;
    }

    [Serializable]
    public struct LatLngLiteral
    {
        public double lat;
        public double lng;
    }

    [Serializable]
    public struct Bounds
    {
        public LatLngLiteral northeast;
        public LatLngLiteral southwest;
    }

    [Serializable]
    public struct PlaceOpeningHoursDto
    {
        public bool open_now;
        public PlaceOpeningHoursPeriodDto[] periods;
        public PlaceSpecialDayDto[] special_days;
        public string type;
        public string[] weekday_text;

        public OpeningHours ToOpeningHours() =>
            new(
                open_now,
                periods?.Select(x => x.ToOpeningHoursPeriod()).ToArray(),
                special_days?.Select(x => x.ToSpecialDay()).ToArray(),
                type,
                weekday_text
            );
    }


    [Serializable]
    public struct PlaceOpeningHoursPeriodDto
    {
        public PlaceOpeningHoursPeriodDetailDto open;
        public PlaceOpeningHoursPeriodDetailDto close;

        public OpeningHoursPeriod ToOpeningHoursPeriod() =>
            new(
                open.ToPlaceOpeningHoursPeriodDetail(),
                close.ToPlaceOpeningHoursPeriodDetail());
    }

    [Serializable]
    public struct PlaceSpecialDayDto
    {
        public string date;
        public bool exceptional_hours;

        public SpecialDay ToSpecialDay() => new(DtoHelper.Rfc3339ToDateTime(date), exceptional_hours);
    }

    [Serializable]
    public struct PlaceOpeningHoursPeriodDetailDto
    {
        public int day;
        public string time;
        public string date;
        public bool truncated;

        public PlaceOpeningHoursPeriodDetail ToPlaceOpeningHoursPeriodDetail()
        {
            var week = day switch
            {
                0 => DayOfWeek.Sunday,
                1 => DayOfWeek.Monday,
                2 => DayOfWeek.Tuesday,
                3 => DayOfWeek.Wednesday,
                4 => DayOfWeek.Thursday,
                5 => DayOfWeek.Friday,
                6 => DayOfWeek.Saturday,
            };

            var dateTime = Rfc3339ToDateTime(date);
            return new PlaceOpeningHoursPeriodDetail(week, dateTime, truncated);
        }

        private DateTime Rfc3339ToDateTime(string rfc3339)
        {
            var hhmm = int.Parse(time);
            var hour = hhmm / 100;
            var minute = hhmm % 100;
            return DtoHelper.Rfc3339ToDateTime(rfc3339).Add(new TimeSpan(hour, minute, 0));
        }
    }

    [Serializable]
    public struct PlacePhotoDto
    {
        public int height;
        public int width;
        public string[] html_attributions;
        public string photo_reference;

        public PlacePhoto ToPlacePhoto() => new(height, width, html_attributions, photo_reference);
    }

    [Serializable]
    public struct PlusCodeDto
    {
        public string global_code;
        public string compound_code;
    }

    [Serializable]
    public struct PlaceReview
    {
        public string author_name;
        public int rating;
        public string relative_time_description;
        public int time;
        public string author_url;
        public string language;
        public string original_language;
        public string profile_photo_url;
        public string text;
        public bool translated;
    }
}