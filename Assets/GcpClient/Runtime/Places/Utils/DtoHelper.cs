﻿using System.Collections.Generic;

namespace GcpClient.Runtime.Places.Utils
{
    public class DtoHelper
    {
        public static IReadOnlyDictionary<string, PlaceType> PlaceTypeMap = new Dictionary<string, PlaceType>()
        {
            { "accounting", PlaceType.Accounting },
            { "airport", PlaceType.Airport },
            { "amusement_park", PlaceType.Amusement_park },
            { "aquarium", PlaceType.Aquarium },
            { "art_gallery", PlaceType.Art_gallery },
            { "atm", PlaceType.Atm },
            { "bakery", PlaceType.Bakery },
            { "bank", PlaceType.Bank },
            { "bar", PlaceType.Bar },
            { "beauty_salon", PlaceType.Beauty_salon },
            { "bicycle_store", PlaceType.Bicycle_store },
            { "book_store", PlaceType.Book_store },
            { "bowling_alley", PlaceType.Bowling_alley },
            { "bus_station", PlaceType.Bus_station },
            { "cafe", PlaceType.Cafe },
            { "campground", PlaceType.Campground },
            { "car_dealer", PlaceType.Car_dealer },
            { "car_rental", PlaceType.Car_rental },
            { "car_repair", PlaceType.Car_repair },
            { "car_wash", PlaceType.Car_wash },
            { "casino", PlaceType.Casino },
            { "cemetery", PlaceType.Cemetery },
            { "church", PlaceType.Church },
            { "city_hall", PlaceType.City_hall },
            { "clothing_store", PlaceType.Clothing_store },
            { "convenience_store", PlaceType.Convenience_store },
            { "courthouse", PlaceType.Courthouse },
            { "dentist", PlaceType.Dentist },
            { "department_store", PlaceType.Department_store },
            { "doctor", PlaceType.Doctor },
            { "drugstore", PlaceType.Drugstore },
            { "electrician", PlaceType.Electrician },
            { "electronics_store", PlaceType.Electronics_store },
            { "embassy", PlaceType.Embassy },
            { "fire_station", PlaceType.Fire_station },
            { "florist", PlaceType.Florist },
            { "funeral_home", PlaceType.Funeral_home },
            { "furniture_store", PlaceType.Furniture_store },
            { "gas_station", PlaceType.Gas_station },
            { "gym", PlaceType.Gym },
            { "hair_care", PlaceType.Hair_care },
            { "hardware_store", PlaceType.Hardware_store },
            { "hindu_temple", PlaceType.Hindu_temple },
            { "home_goods_store", PlaceType.Home_goods_store },
            { "hospital", PlaceType.Hospital },
            { "insurance_agency", PlaceType.Insurance_agency },
            { "jewelry_store", PlaceType.Jewelry_store },
            { "laundry", PlaceType.Laundry },
            { "lawyer", PlaceType.Lawyer },
            { "library", PlaceType.Library },
            { "light_rail_station", PlaceType.Light_rail_station },
            { "liquor_store", PlaceType.Liquor_store },
            { "local_government_office", PlaceType.Local_government_office },
            { "locksmith", PlaceType.Locksmith },
            { "lodging", PlaceType.Lodging },
            { "meal_delivery", PlaceType.Meal_delivery },
            { "meal_takeaway", PlaceType.Meal_takeaway },
            { "mosque", PlaceType.Mosque },
            { "movie_rental", PlaceType.Movie_rental },
            { "movie_theater", PlaceType.Movie_theater },
            { "moving_company", PlaceType.Moving_company },
            { "museum", PlaceType.Museum },
            { "night_club", PlaceType.Night_club },
            { "painter", PlaceType.Painter },
            { "park", PlaceType.Park },
            { "parking", PlaceType.Parking },
            { "pet_store", PlaceType.Pet_store },
            { "pharmacy", PlaceType.Pharmacy },
            { "physiotherapist", PlaceType.Physiotherapist },
            { "plumber", PlaceType.Plumber },
            { "police", PlaceType.Police },
            { "post_office", PlaceType.Post_office },
            { "primary_school", PlaceType.Primary_school },
            { "real_estate_agency", PlaceType.Real_estate_agency },
            { "restaurant", PlaceType.Restaurant },
            { "roofing_contractor", PlaceType.Roofing_contractor },
            { "rv_park", PlaceType.Rv_park },
            { "school", PlaceType.School },
            { "secondary_school", PlaceType.Secondary_school },
            { "shoe_store", PlaceType.Shoe_store },
            { "shopping_mall", PlaceType.Shopping_mall },
            { "spa", PlaceType.Spa },
            { "stadium", PlaceType.Stadium },
            { "storage", PlaceType.Storage },
            { "store", PlaceType.Store },
            { "subway_station", PlaceType.Subway_station },
            { "supermarket", PlaceType.Supermarket },
            { "synagogue", PlaceType.Synagogue },
            { "taxi_stand", PlaceType.Taxi_stand },
            { "tourist_attraction", PlaceType.Tourist_attraction },
            { "train_station", PlaceType.Train_station },
            { "transit_station", PlaceType.Transit_station },
            { "travel_agency", PlaceType.Travel_agency },
            { "university", PlaceType.University },
            { "veterinary_care", PlaceType.Veterinary_care },
            { "zoo", PlaceType.Zoo },

            { "administrative_area_level_1", PlaceType.Administrative_area_level_1 },
            { "administrative_area_level_2", PlaceType.Administrative_area_level_2 },
            { "administrative_area_level_3", PlaceType.Administrative_area_level_3 },
            { "administrative_area_level_4", PlaceType.Administrative_area_level_4 },
            { "administrative_area_level_5", PlaceType.Administrative_area_level_5 },
            { "administrative_area_level_6", PlaceType.Administrative_area_level_6 },
            { "administrative_area_level_7", PlaceType.Administrative_area_level_7 },
            { "archipelago", PlaceType.Archipelago },
            { "colloquial_area", PlaceType.Colloquial_area },
            { "continent", PlaceType.Continent },
            { "country", PlaceType.Country },
            { "establishment", PlaceType.Establishment },
            { "finance", PlaceType.Finance },
            { "floor", PlaceType.Floor },
            { "food", PlaceType.Food },
            { "general_contractor", PlaceType.General_contractor },
            { "geocode", PlaceType.Geocode },
            { "health", PlaceType.Health },
            { "intersection", PlaceType.Intersection },
            { "landmark", PlaceType.Landmark },
            { "locality", PlaceType.Locality },
            { "natural_feature", PlaceType.Natural_feature },
            { "neighborhood", PlaceType.Neighborhood },
            { "place_of_worship", PlaceType.Place_of_worship },
            { "plus_code", PlaceType.Plus_code },
            { "point_of_interest", PlaceType.Point_of_interest },
            { "political", PlaceType.Political },
            { "post_box", PlaceType.Post_box },
            { "postal_code", PlaceType.Postal_code },
            { "postal_code_prefix", PlaceType.Postal_code_prefix },
            { "postal_code_suffix", PlaceType.Postal_code_suffix },
            { "postal_town", PlaceType.Postal_town },
            { "premise", PlaceType.Premise },
            { "room", PlaceType.Room },
            { "route", PlaceType.Route },
            { "street_address", PlaceType.Street_address },
            { "street_number", PlaceType.Street_number },
            { "sublocality", PlaceType.Sublocality },
            { "sublocality_level_1", PlaceType.Sublocality_level_1 },
            { "sublocality_level_2", PlaceType.Sublocality_level_2 },
            { "sublocality_level_3", PlaceType.Sublocality_level_3 },
            { "sublocality_level_4", PlaceType.Sublocality_level_4 },
            { "sublocality_level_5", PlaceType.Sublocality_level_5 },
            { "subpremise", PlaceType.Subpremise },
            { "town_square", PlaceType.Town_square },
        };

        public static IReadOnlyDictionary<string, PlaceTypeTable1> PlaceTypeTable1Map = new Dictionary<string, PlaceTypeTable1>()
        {
            { "accounting", PlaceTypeTable1.Accounting },
            { "airport", PlaceTypeTable1.Airport },
            { "amusement_park", PlaceTypeTable1.Amusement_park },
            { "aquarium", PlaceTypeTable1.Aquarium },
            { "art_gallery", PlaceTypeTable1.Art_gallery },
            { "atm", PlaceTypeTable1.Atm },
            { "bakery", PlaceTypeTable1.Bakery },
            { "bank", PlaceTypeTable1.Bank },
            { "bar", PlaceTypeTable1.Bar },
            { "beauty_salon", PlaceTypeTable1.Beauty_salon },
            { "bicycle_store", PlaceTypeTable1.Bicycle_store },
            { "book_store", PlaceTypeTable1.Book_store },
            { "bowling_alley", PlaceTypeTable1.Bowling_alley },
            { "bus_station", PlaceTypeTable1.Bus_station },
            { "cafe", PlaceTypeTable1.Cafe },
            { "campground", PlaceTypeTable1.Campground },
            { "car_dealer", PlaceTypeTable1.Car_dealer },
            { "car_rental", PlaceTypeTable1.Car_rental },
            { "car_repair", PlaceTypeTable1.Car_repair },
            { "car_wash", PlaceTypeTable1.Car_wash },
            { "casino", PlaceTypeTable1.Casino },
            { "cemetery", PlaceTypeTable1.Cemetery },
            { "church", PlaceTypeTable1.Church },
            { "city_hall", PlaceTypeTable1.City_hall },
            { "clothing_store", PlaceTypeTable1.Clothing_store },
            { "convenience_store", PlaceTypeTable1.Convenience_store },
            { "courthouse", PlaceTypeTable1.Courthouse },
            { "dentist", PlaceTypeTable1.Dentist },
            { "department_store", PlaceTypeTable1.Department_store },
            { "doctor", PlaceTypeTable1.Doctor },
            { "drugstore", PlaceTypeTable1.Drugstore },
            { "electrician", PlaceTypeTable1.Electrician },
            { "electronics_store", PlaceTypeTable1.Electronics_store },
            { "embassy", PlaceTypeTable1.Embassy },
            { "fire_station", PlaceTypeTable1.Fire_station },
            { "florist", PlaceTypeTable1.Florist },
            { "funeral_home", PlaceTypeTable1.Funeral_home },
            { "furniture_store", PlaceTypeTable1.Furniture_store },
            { "gas_station", PlaceTypeTable1.Gas_station },
            { "gym", PlaceTypeTable1.Gym },
            { "hair_care", PlaceTypeTable1.Hair_care },
            { "hardware_store", PlaceTypeTable1.Hardware_store },
            { "hindu_temple", PlaceTypeTable1.Hindu_temple },
            { "home_goods_store", PlaceTypeTable1.Home_goods_store },
            { "hospital", PlaceTypeTable1.Hospital },
            { "insurance_agency", PlaceTypeTable1.Insurance_agency },
            { "jewelry_store", PlaceTypeTable1.Jewelry_store },
            { "laundry", PlaceTypeTable1.Laundry },
            { "lawyer", PlaceTypeTable1.Lawyer },
            { "library", PlaceTypeTable1.Library },
            { "light_rail_station", PlaceTypeTable1.Light_rail_station },
            { "liquor_store", PlaceTypeTable1.Liquor_store },
            { "local_government_office", PlaceTypeTable1.Local_government_office },
            { "locksmith", PlaceTypeTable1.Locksmith },
            { "lodging", PlaceTypeTable1.Lodging },
            { "meal_delivery", PlaceTypeTable1.Meal_delivery },
            { "meal_takeaway", PlaceTypeTable1.Meal_takeaway },
            { "mosque", PlaceTypeTable1.Mosque },
            { "movie_rental", PlaceTypeTable1.Movie_rental },
            { "movie_theater", PlaceTypeTable1.Movie_theater },
            { "moving_company", PlaceTypeTable1.Moving_company },
            { "museum", PlaceTypeTable1.Museum },
            { "night_club", PlaceTypeTable1.Night_club },
            { "painter", PlaceTypeTable1.Painter },
            { "park", PlaceTypeTable1.Park },
            { "parking", PlaceTypeTable1.Parking },
            { "pet_store", PlaceTypeTable1.Pet_store },
            { "pharmacy", PlaceTypeTable1.Pharmacy },
            { "physiotherapist", PlaceTypeTable1.Physiotherapist },
            { "plumber", PlaceTypeTable1.Plumber },
            { "police", PlaceTypeTable1.Police },
            { "post_office", PlaceTypeTable1.Post_office },
            { "primary_school", PlaceTypeTable1.Primary_school },
            { "real_estate_agency", PlaceTypeTable1.Real_estate_agency },
            { "restaurant", PlaceTypeTable1.Restaurant },
            { "roofing_contractor", PlaceTypeTable1.Roofing_contractor },
            { "rv_park", PlaceTypeTable1.Rv_park },
            { "school", PlaceTypeTable1.School },
            { "secondary_school", PlaceTypeTable1.Secondary_school },
            { "shoe_store", PlaceTypeTable1.Shoe_store },
            { "shopping_mall", PlaceTypeTable1.Shopping_mall },
            { "spa", PlaceTypeTable1.Spa },
            { "stadium", PlaceTypeTable1.Stadium },
            { "storage", PlaceTypeTable1.Storage },
            { "store", PlaceTypeTable1.Store },
            { "subway_station", PlaceTypeTable1.Subway_station },
            { "supermarket", PlaceTypeTable1.Supermarket },
            { "synagogue", PlaceTypeTable1.Synagogue },
            { "taxi_stand", PlaceTypeTable1.Taxi_stand },
            { "tourist_attraction", PlaceTypeTable1.Tourist_attraction },
            { "train_station", PlaceTypeTable1.Train_station },
            { "transit_station", PlaceTypeTable1.Transit_station },
            { "travel_agency", PlaceTypeTable1.Travel_agency },
            { "university", PlaceTypeTable1.University },
            { "veterinary_care", PlaceTypeTable1.Veterinary_care },
            { "zoo", PlaceTypeTable1.Zoo },
        };

        public static IReadOnlyDictionary<string, PlaceTypeTable2> PlaceTypeTable2Map = new Dictionary<string, PlaceTypeTable2>
        {
            { "administrative_area_level_1", PlaceTypeTable2.Administrative_area_level_1 },
            { "administrative_area_level_2", PlaceTypeTable2.Administrative_area_level_2 },
            { "administrative_area_level_3", PlaceTypeTable2.Administrative_area_level_3 },
            { "administrative_area_level_4", PlaceTypeTable2.Administrative_area_level_4 },
            { "administrative_area_level_5", PlaceTypeTable2.Administrative_area_level_5 },
            { "administrative_area_level_6", PlaceTypeTable2.Administrative_area_level_6 },
            { "administrative_area_level_7", PlaceTypeTable2.Administrative_area_level_7 },
            { "archipelago", PlaceTypeTable2.Archipelago },
            { "colloquial_area", PlaceTypeTable2.Colloquial_area },
            { "continent", PlaceTypeTable2.Continent },
            { "country", PlaceTypeTable2.Country },
            { "establishment", PlaceTypeTable2.Establishment },
            { "finance", PlaceTypeTable2.Finance },
            { "floor", PlaceTypeTable2.Floor },
            { "food", PlaceTypeTable2.Food },
            { "general_contractor", PlaceTypeTable2.General_contractor },
            { "geocode", PlaceTypeTable2.Geocode },
            { "health", PlaceTypeTable2.Health },
            { "intersection", PlaceTypeTable2.Intersection },
            { "landmark", PlaceTypeTable2.Landmark },
            { "locality", PlaceTypeTable2.Locality },
            { "natural_feature", PlaceTypeTable2.Natural_feature },
            { "neighborhood", PlaceTypeTable2.Neighborhood },
            { "place_of_worship", PlaceTypeTable2.Place_of_worship },
            { "plus_code", PlaceTypeTable2.Plus_code },
            { "point_of_interest", PlaceTypeTable2.Point_of_interest },
            { "political", PlaceTypeTable2.Political },
            { "post_box", PlaceTypeTable2.Post_box },
            { "postal_code", PlaceTypeTable2.Postal_code },
            { "postal_code_prefix", PlaceTypeTable2.Postal_code_prefix },
            { "postal_code_suffix", PlaceTypeTable2.Postal_code_suffix },
            { "postal_town", PlaceTypeTable2.Postal_town },
            { "premise", PlaceTypeTable2.Premise },
            { "room", PlaceTypeTable2.Room },
            { "route", PlaceTypeTable2.Route },
            { "street_address", PlaceTypeTable2.Street_address },
            { "street_number", PlaceTypeTable2.Street_number },
            { "sublocality", PlaceTypeTable2.Sublocality },
            { "sublocality_level_1", PlaceTypeTable2.Sublocality_level_1 },
            { "sublocality_level_2", PlaceTypeTable2.Sublocality_level_2 },
            { "sublocality_level_3", PlaceTypeTable2.Sublocality_level_3 },
            { "sublocality_level_4", PlaceTypeTable2.Sublocality_level_4 },
            { "sublocality_level_5", PlaceTypeTable2.Sublocality_level_5 },
            { "subpremise", PlaceTypeTable2.Subpremise },
            { "town_square", PlaceTypeTable2.Town_square },
        };

        public static IReadOnlyDictionary<string, BusinessStatus> BusinessStatusTable = new Dictionary<string, BusinessStatus>
        {
            { "OPERATIONAL", BusinessStatus.Operational },
            { "CLOSED_TEMPORARILY", BusinessStatus.ClosedTemporarily },
            { "CLOSED_PERMANENTLY", BusinessStatus.ClosedPermanently },
        };

        /// <summary>
        /// https://developers.google.com/maps/documentation/places/web-service/search-nearby#PlacesSearchStatus
        /// </summary>
        public static IReadOnlyDictionary<string, PlacesSearchStatus> PlacesSearchStatusTable = new Dictionary<string, PlacesSearchStatus>
        {
            { "OK", PlacesSearchStatus.Ok },
            { "ZERO_RESULTS", PlacesSearchStatus.ZeroResults },
            { "INVALID_REQUEST", PlacesSearchStatus.InvalidRequest },
            { "OVER_QUERY_LIMIT", PlacesSearchStatus.OverQueryLimit },
            { "REQUEST_DENIED", PlacesSearchStatus.RequestDenied },
            { "UNKNOWN_ERROR", PlacesSearchStatus.UnknownError },
        };
    }
}