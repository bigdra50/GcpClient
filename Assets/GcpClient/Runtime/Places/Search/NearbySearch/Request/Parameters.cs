using System;

namespace GcpClient.Runtime.Places.Search.NearbySearch.Request
{
    #region Required

    public struct Location : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Location(string value)
        {
            Key = "location";
            Value = value;
        }

        public Location(double latitude, double longitude)
        {
            Key = "location";
            Value = $"{latitude},{longitude}";
        }
    }

    #endregion

    #region Optional

    /// <summary>
    /// The text string on which to search, for example: "restaurant" or "123 Main Street".
    /// This must be a place name, address, or category of establishments.
    /// Any other types of input can generate errors and are not guaranteed to return valid results.
    /// The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.
    /// Explicitly including location information using this parameter may conflict with the location, radius, and rankby parameters, causing unexpected results.
    /// If this parameter is omitted, places with a business_status of CLOSED_TEMPORARILY or CLOSED_PERMANENTLY will not be returned.
    /// </summary>
    public struct Keyword : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Keyword(string value)
        {
            Key = "keyword";
            Value = value;
        }
    }

    /// <summary>
    /// The language in which to return results.
    /// See the list of supported languages.
    /// Google often updates the supported languages, so this list may not be exhaustive.
    /// If language is not supplied, the API attempts to use the preferred language as specified in the Accept-Language header.
    /// The API does its best to provide a street address that is readable for both the user and locals.
    /// To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language.All other addresses are returned in the preferred language.
    /// Address components are all returned in the same language, which is chosen from the first component.
    /// If a name is not available in the preferred language, the API uses the closest match.
    /// The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned.
    /// The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language
    /// but not in another.For example, utca and tér are synonyms for street in Hungarian.
    /// </summary>
    public struct Language : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Language(string value)
        {
            Key = "language";
            Value = value;
        }

        public Language(LanguageType lang)
        {
            Key = "language";
            Value = lang switch
            {
                LanguageType.Ja => "ja",
                LanguageType.En => "en",
                _ => throw new ArgumentOutOfRangeException(nameof(lang), lang, null)
            };
        }
    }

    /// <summary>
    /// Restricts results to only those places within the specified range.
    /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive.
    /// The exact amount indicated by a specific value will vary from region to region.
    /// </summary>
    public struct MaxPrice : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public MaxPrice(int value)
        {
            Key = "maxprice";
            Value = $"{Math.Max(Math.Min(value, 0), 4)}";
        }
    }

    /// <summary>
    /// Restricts results to only those places within the specified range.
    /// Valid values range between 0 (most affordable) to 4 (most expensive), inclusive.
    /// The exact amount indicated by a specific value will vary from region to region.
    /// </summary>
    public struct MinPrice : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public MinPrice(int value)
        {
            Key = "minprice";
            Value = $"{Math.Max(Math.Min(value, 0), 4)}";
        }
    }

    /// <summary>
    /// Returns only those places that are open for business at the time the query is sent.
    /// Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.
    /// </summary>
    public struct OpenNow : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public OpenNow(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    /// <summary>
    /// Returns up to 20 results from a previously run search.
    /// Setting a pagetoken parameter will execute a search with the same parameters used previously
    /// — all parameters other than pagetoken will be ignored.
    /// </summary>
    public struct PageToken : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public PageToken(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    /// <summary>
    /// Defines the distance (in meters) within which to return place results.
    /// You may bias results to a specified circle by passing a location and a radius parameter.
    /// Doing so instructs the Places service to prefer showing results within that circle; results outside of the defined area may still be displayed.
    /// The radius will automatically be clamped to a maximum value depending on the type of search and other parameters.
    /// - Autocomplete: 50,000 meters
    /// - Nearby Search:
    ///   - with keyword or name: 50,000 meters
    ///   - without keyword or name
    ///     - Up to 50,000 meters, adjusted dynamically based on area density, independent of rankby parameter.
    ///     - When using rankby=distance, the radius parameter will not be accepted, and will result in an INVALID_REQUEST.
    /// - Query Autocomplete: 50,000 meters
    /// - Text Search: 50,000 meters
    /// </summary>
    public struct Radius : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Radius(int value)
        {
            Key = "radius";
            Value = $"{Math.Max(value, 0)}";
        }
    }

    /// <summary>
    /// Specifies the order in which results are listed. Possible values are:
    /// - prominence (default). This option sorts results based on their importance.
    ///   Ranking will favor prominent places within the set radius over nearby places that match but that are less prominent.
    ///   Prominence can be affected by a place's ranking in Google's index, global popularity, and other factors.
    ///   When prominence is specified, the radius parameter is required.
    /// - distance. This option biases search results in ascending order by their distance from the specified location.
    ///   When distance is specified, one or more of keyword, name, or type is required and radius is disallowed.
    /// </summary>
    public struct RankBy : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public RankBy(RankByMethod rankByMethod)
        {
            Key = "rankby";
            Value = rankByMethod switch
            {
                RankByMethod.Prominence => "prominence",
                RankByMethod.Distance => "distance",
                _ => throw new ArgumentOutOfRangeException(nameof(rankByMethod), rankByMethod, null)
            };
        }

        public enum RankByMethod
        {
            Prominence,
            Distance
        }
    }

    /// <summary>
    /// Restricts the results to places matching the specified type.
    /// Only one type may be specified. If more than one type is provided, all types following the first entry are ignored.
    /// - type=hospital|pharmacy|doctor becomes type=hospital
    /// - type=hospital,pharmacy,doctor is ignored entirely
    /// </summary>
    public struct Type : IParameter
    {
        public string Key { get; }
        public string Value { get; }

        public Type(PlaceTypeTable1 placeType)
        {
            Key = "type";
            Value = placeType.ToString().ToLower();
        }
    }

    #endregion
}