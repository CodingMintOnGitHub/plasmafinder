using System;
namespace PlasmaFinder.Constants
{
    public static class ApiConstants
    {
        public const string IMAGE_FOLDER_PATH = "/rfidimages/";
        public const string API_BASE_URL = "https://codingmint-covid-resource.herokuapp.com/";
        public const string ACTION_TYPE_ADD_RESOURCE = "Resource";
        public const string URL_ACTION_TYPE_AUTHVALUES = "http://codingmint-covid-resource.herokuapp.com/api/AuthValues";
        public const string ACTION_TYPE_CLEAR = "clear";
    }

    public enum Resource_Type
    {
        Oxygen = 1,
        Plasma = 2,
        Blood = 3,
        Clothes = 4,
        Food = 5
    }

    public enum Gender_Type
    {
        Male = 1,
        Female = 2,
        Transgender = 3,
        PreferNotSay = 4
    }
}
