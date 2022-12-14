namespace GcpClient.Runtime.Places
{
    /// <summary>
    /// https://developers.google.com/maps/faq#languagesupport
    /// </summary>
    public enum LanguageType
    {
        Ja, // 日本語
        En, // 英語
    }

    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/search-nearby#Place-business_status
    /// </summary>
    public enum BusinessStatus
    {
        Operational,
        ClosedTemporarily,
        ClosedPermanently,
        Empty,
    }

    public enum PlacesSearchStatus
    {
        Ok,
        ZeroResults,
        InvalidRequest,
        OverQueryLimit,
        RequestDenied,
        UnknownError,
    }

    public enum PlaceDetailsStatus
    {
        Ok,
        ZeroResults,
        NotFound,
        InvalidRequest,
        OverQueryLimit,
        RequestDenied,
        UnknownError,
    }


    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/search-nearby#PlaceOpeningHours-type
    /// </summary>
    public enum SecondaryOpeningHoursType
    {
        DriveThrough,
        HappyHour,
        Delivery,
        Takeout,
        Kitchen,
        BreakFast,
        Lunch,
        Dinner,
        Brunch,
        Pickup,
        SeniourHours
    }


    public enum PlaceType
    {
        Accounting,
        Airport,
        Amusement_park,
        Aquarium,
        Art_gallery,
        Atm,
        Bakery,
        Bank,
        Bar,
        Beauty_salon,
        Bicycle_store,
        Book_store,
        Bowling_alley,
        Bus_station,
        Cafe,
        Campground,
        Car_dealer,
        Car_rental,
        Car_repair,
        Car_wash,
        Casino,
        Cemetery,
        Church,
        City_hall,
        Clothing_store,
        Convenience_store,
        Courthouse,
        Dentist,
        Department_store,
        Doctor,
        Drugstore,
        Electrician,
        Electronics_store,
        Embassy,
        Fire_station,
        Florist,
        Funeral_home,
        Furniture_store,
        Gas_station,
        Gym,
        Hair_care,
        Hardware_store,
        Hindu_temple,
        Home_goods_store,
        Hospital,
        Insurance_agency,
        Jewelry_store,
        Laundry,
        Lawyer,
        Library,
        Light_rail_station,
        Liquor_store,
        Local_government_office,
        Locksmith,
        Lodging,
        Meal_delivery,
        Meal_takeaway,
        Mosque,
        Movie_rental,
        Movie_theater,
        Moving_company,
        Museum,
        Night_club,
        Painter,
        Park,
        Parking,
        Pet_store,
        Pharmacy,
        Physiotherapist,
        Plumber,
        Police,
        Post_office,
        Primary_school,
        Real_estate_agency,
        Restaurant,
        Roofing_contractor,
        Rv_park,
        School,
        Secondary_school,
        Shoe_store,
        Shopping_mall,
        Spa,
        Stadium,
        Storage,
        Store,
        Subway_station,
        Supermarket,
        Synagogue,
        Taxi_stand,
        Tourist_attraction,
        Train_station,
        Transit_station,
        Travel_agency,
        University,
        Veterinary_care,
        Zoo,

        Administrative_area_level_1,
        Administrative_area_level_2,
        Administrative_area_level_3,
        Administrative_area_level_4,
        Administrative_area_level_5,
        Administrative_area_level_6,
        Administrative_area_level_7,
        Archipelago,
        Colloquial_area,
        Continent,
        Country,
        Establishment,
        Finance,
        Floor,
        Food,
        General_contractor,
        Geocode,
        Health,
        Intersection,
        Landmark,
        Locality,
        Natural_feature,
        Neighborhood,
        Place_of_worship,
        Plus_code,
        Point_of_interest,
        Political,
        Post_box,
        Postal_code,
        Postal_code_prefix,
        Postal_code_suffix,
        Postal_town,
        Premise,
        Room,
        Route,
        Street_address,
        Street_number,
        Sublocality,
        Sublocality_level_1,
        Sublocality_level_2,
        Sublocality_level_3,
        Sublocality_level_4,
        Sublocality_level_5,
        Subpremise,
        Town_square,
    }

    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table1
    /// </summary>
    public enum PlaceTypeTable1
    {
        Accounting,
        Airport,
        Amusement_park,
        Aquarium,
        Art_gallery,
        Atm,
        Bakery,
        Bank,
        Bar,
        Beauty_salon,
        Bicycle_store,
        Book_store,
        Bowling_alley,
        Bus_station,
        Cafe,
        Campground,
        Car_dealer,
        Car_rental,
        Car_repair,
        Car_wash,
        Casino,
        Cemetery,
        Church,
        City_hall,
        Clothing_store,
        Convenience_store,
        Courthouse,
        Dentist,
        Department_store,
        Doctor,
        Drugstore,
        Electrician,
        Electronics_store,
        Embassy,
        Fire_station,
        Florist,
        Funeral_home,
        Furniture_store,
        Gas_station,
        Gym,
        Hair_care,
        Hardware_store,
        Hindu_temple,
        Home_goods_store,
        Hospital,
        Insurance_agency,
        Jewelry_store,
        Laundry,
        Lawyer,
        Library,
        Light_rail_station,
        Liquor_store,
        Local_government_office,
        Locksmith,
        Lodging,
        Meal_delivery,
        Meal_takeaway,
        Mosque,
        Movie_rental,
        Movie_theater,
        Moving_company,
        Museum,
        Night_club,
        Painter,
        Park,
        Parking,
        Pet_store,
        Pharmacy,
        Physiotherapist,
        Plumber,
        Police,
        Post_office,
        Primary_school,
        Real_estate_agency,
        Restaurant,
        Roofing_contractor,
        Rv_park,
        School,
        Secondary_school,
        Shoe_store,
        Shopping_mall,
        Spa,
        Stadium,
        Storage,
        Store,
        Subway_station,
        Supermarket,
        Synagogue,
        Taxi_stand,
        Tourist_attraction,
        Train_station,
        Transit_station,
        Travel_agency,
        University,
        Veterinary_care,
        Zoo,
    }

    /// <summary>
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table2
    /// </summary>
    public enum PlaceTypeTable2
    {
        Administrative_area_level_1,
        Administrative_area_level_2,
        Administrative_area_level_3,
        Administrative_area_level_4,
        Administrative_area_level_5,
        Administrative_area_level_6,
        Administrative_area_level_7,
        Archipelago,
        Colloquial_area,
        Continent,
        Country,
        Establishment,
        Finance,
        Floor,
        Food,
        General_contractor,
        Geocode,
        Health,
        Intersection,
        Landmark,
        Locality,
        Natural_feature,
        Neighborhood,
        Place_of_worship,
        Plus_code,
        Point_of_interest,
        Political,
        Post_box,
        Postal_code,
        Postal_code_prefix,
        Postal_code_suffix,
        Postal_town,
        Premise,
        Room,
        Route,
        Street_address,
        Street_number,
        Sublocality,
        Sublocality_level_1,
        Sublocality_level_2,
        Sublocality_level_3,
        Sublocality_level_4,
        Sublocality_level_5,
        Subpremise,
        Town_square,
    }
}