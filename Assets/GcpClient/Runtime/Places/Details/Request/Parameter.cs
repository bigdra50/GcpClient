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
        public string Value => string.Join(',', _flags);
        private static readonly List<string> _flags = new();

        public Fields(BasicCategory basic)
        {
            Init(basic);
        }

        public Fields(ContactCategory contact)
        {
            Init(contact);
        }

        public Fields(AtmosphereCategory atmosphere)
        {
            Init(atmosphere);
        }

        public Fields(BasicCategory basic, ContactCategory contact) : this(basic)
        {
            Init(contact);
        }

        public Fields(BasicCategory basic, AtmosphereCategory atmosphere) : this(basic)
        {
            Init(atmosphere);
        }

        public Fields(ContactCategory contact, AtmosphereCategory atmosphere) : this(contact)
        {
            Init(atmosphere);
        }

        public Fields(BasicCategory basic, ContactCategory contact, AtmosphereCategory atmosphere) : this(basic, contact)
        {
            Init(atmosphere);
        }


        private void Init(BasicCategory flag)
        {
            foreach (BasicCategory category in Enum.GetValues(typeof(BasicCategory)))
            {
                if (category == BasicCategory.None) continue;
                if (category == BasicCategory.All) continue;
                if (!flag.HasBitFlag(category)) continue;
                _flags.Add(category.CategoryToString());
            }
        }

        private void Init(ContactCategory flag)
        {
            foreach (ContactCategory category in Enum.GetValues(typeof(ContactCategory)))
            {
                if (category == ContactCategory.None) continue;
                if (category == ContactCategory.All) continue;
                if (!flag.HasBitFlag(category)) continue;
                _flags.Add(category.CategoryToString());
            }
        }

        private void Init(AtmosphereCategory flag)
        {
            foreach (AtmosphereCategory category in Enum.GetValues(typeof(AtmosphereCategory)))
            {
                if (category == AtmosphereCategory.None) continue;
                if (category == AtmosphereCategory.All) continue;
                if (!flag.HasBitFlag(category)) continue;
                _flags.Add(category.CategoryToString());
            }
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