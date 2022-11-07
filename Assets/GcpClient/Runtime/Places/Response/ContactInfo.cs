using System;

namespace GcpClient.Runtime.Places.Response
{
    public struct ContactInfo
    {
        // TODO: impl

        public ContactInfo(
            PlaceOpeningHoursDto currentOpeningHours,
            string formattedPhoneNumber,
            string internationalPhoneNumber,
            PlaceOpeningHoursDto openingHours,
            PlaceOpeningHoursDto secondaryOpeningHours,
            string website)
        {
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