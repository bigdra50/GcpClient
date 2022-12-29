using System;
using GcpClient.Runtime.Places.Response;

namespace GcpClient.Runtime.Places.Field
{
    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/place-data-fields#atmosphere
    /// </summary>
    public struct AtmosphereInfo
    {
        /// <summary>
        /// 事業者がカーブサイドピックアップをサポートしているかどうか 
        /// </summary>
        public bool IsSupportCurbsidePickup { get; }

        /// <summary>
        /// 事業者が宅配をサポートしているかどうか 
        /// </summary>
        public bool IsSupportDelivery { get; }

        /// <summary>
        /// 屋内席、屋外席のオプションに対応しているかどうか
        /// </summary>
        public bool IsSupportDineIn { get; }

        /// <summary>
        /// 場所の要約を含んでいます。
        /// 要約は、テキストによる概要で構成され、該当する場合はこれらの言語コードも含まれます。
        /// 要約のテキストはそのまま表示される必要があり、修正または変更することはできません。
        /// </summary>
        public PlaceEditorialSummary EditorialSummary { get; }

        public int PriceLevel { get; }

        public double Rating { get; }

        public PlaceReview[] Reviews { get; }
        public bool IsSupportTakeout { get; }
        public int UserRatingsTotal { get; }

        public AtmosphereInfo(
            bool curbsidePickup,
            bool delivery,
            bool dineIn,
            PlaceEditorialSummary editorialSummary,
            int priceLevel,
            double rating,
            PlaceReview[] reviews,
            bool takeout,
            int userRatingsTotal)
        {
            IsSupportCurbsidePickup = curbsidePickup;
            IsSupportDelivery = delivery;
            IsSupportDineIn = dineIn;
            EditorialSummary = editorialSummary;
            PriceLevel = priceLevel;
            Rating = rating;
            Reviews = reviews;
            IsSupportTakeout = takeout;
            UserRatingsTotal = userRatingsTotal;
        }
    }
}