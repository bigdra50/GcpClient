using System;
using System.Collections.Generic;
using GcpClient.Runtime.Places.Field;

namespace GcpClient.Runtime.Places.Details.Request
{
    public struct PlaceId : IParameter
    {
        public string Key => "place_id";
        public string Value { get; }

        public PlaceId(string value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/details#fields
    /// </summary>
    public struct Fields : IParameter
    {
        public string Key => "fields";
        public string Value { get; }

        public Fields(string raw)
        {
            Value = raw;
        }

        public Fields(BasicCategory basicFlag)
        {
            var fields = new List<string>();
            foreach (BasicCategory basic in Enum.GetValues(typeof(BasicCategory)))
            {
                if (!basicFlag.HasBitFlag(basic)) continue;
                fields.Add(basic.CategoryToString());
            }

            Value = string.Join(',', fields);
        }
    }

    public struct Language : IParameter
    {
        public string Key => "language";
        public string Value { get; }

        public Language(LanguageType languageType)
        {
            Value = languageType switch
            {
                LanguageType.Ja => "ja",
                LanguageType.En => "en",
                _ => throw new ArgumentOutOfRangeException(nameof(languageType), languageType, null)
            };
        }
    }

    public struct Region : IParameter
    {
        public string Key => "region";
        public string Value { get; }
    }

    public struct ReviewsNoTranslation : IParameter
    {
        public string Key => "reviews_no_translations";
        public string Value { get; }

        public ReviewsNoTranslation(bool noTranslation)
        {
            Value = noTranslation ? "true" : "false";
        }
    }

    public struct ReviewsSort : IParameter
    {
        public string Key => "reviews_sort";
        public string Value { get; }

        public ReviewsSort(SortType sortType)
        {
            Value = sortType switch
            {
                SortType.MostRelevant => "most_relevant",
                SortType.Newest => "newest",
                _ => throw new ArgumentOutOfRangeException(nameof(sortType), sortType, null)
            };
        }

        public enum SortType
        {
            MostRelevant,
            Newest,
        }
    }

    public struct SessionToken : IParameter
    {
        public string Key => "sessiontoken";
        public string Value { get; }
    }
}