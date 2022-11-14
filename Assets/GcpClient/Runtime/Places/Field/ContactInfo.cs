using System;
using GcpClient.Runtime.Places.Response;

namespace GcpClient.Runtime.Places.Field
{
    public struct ContactInfo
    {
        // TODO: impl
        public string FormattedPhoneNumber => _formattedPhoneNumber;
        public string InternationalPhoneNumber => _internationalPhoneNumber;
        
        private readonly string _formattedPhoneNumber;
        private readonly string _internationalPhoneNumber;

        private readonly OpeningHours _openingHours;
        private readonly OpeningHours _currentOpeningHours;
        private readonly OpeningHours _secondaryOpeningHours;
        private readonly string _website;

        public ContactInfo(
            string formattedPhoneNumber,
            string internationalPhoneNumber,
            PlaceOpeningHoursDto openingHours,
            PlaceOpeningHoursDto currentOpeningHours,
            PlaceOpeningHoursDto secondaryOpeningHours,
            string website)
        {
            _formattedPhoneNumber = formattedPhoneNumber;
            _internationalPhoneNumber = internationalPhoneNumber;
            _openingHours = openingHours.ToOpeningHours();
            _currentOpeningHours = currentOpeningHours.ToOpeningHours();
            _secondaryOpeningHours = secondaryOpeningHours.ToOpeningHours();
            _website = website;
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

    public struct OpeningHours
    {
        public bool IsOpenNow { get; }

        public OpeningHoursPeriod[] Periods { get; }

        public SpecialDay[] SpecialDays { get; }
        public string Type { get; }
        public string[] WeekDayTexts { get; }

        public OpeningHours(bool isOpenNow, OpeningHoursPeriod[] periods, SpecialDay[] specialDays, string type, string[] weekDayTexts)
        {
            IsOpenNow = isOpenNow;
            Periods = periods;
            SpecialDays = specialDays;
            Type = type;
            WeekDayTexts = weekDayTexts;
        }
    }

    public struct OpeningHoursPeriod
    {
        public PlaceOpeningHoursPeriodDetail OpenDetail { get; }
        public PlaceOpeningHoursPeriodDetail CloseDetail { get; }

        public OpeningHoursPeriod(PlaceOpeningHoursPeriodDetail openDetail, PlaceOpeningHoursPeriodDetail closeDetail)
        {
            OpenDetail = openDetail;
            CloseDetail = closeDetail;
        }
    }

    public struct SpecialDay
    {
        public DateTime Date { get; }

        /// <summary>
        /// この日に例外的な時間がある場合、true を返す。
        /// Trueの場合、この日に少なくとも1つの例外が存在することを意味します。
        /// 例外があると、current_opening_hoursとsecondary_opening_hoursのサブフィールド(periods, weekday_text, open_nowなど)に異なる値が発生することになります。
        /// 例外は時間に適用され、時間は他のフィールドを生成するために使用されます。
        /// </summary>
        /// <returns></returns>
        public bool HasExceptionalHours { get; }

        public SpecialDay(DateTime date, bool hasExceptionalHours)
        {
            Date = date;
            HasExceptionalHours = hasExceptionalHours;
        }
    }
}