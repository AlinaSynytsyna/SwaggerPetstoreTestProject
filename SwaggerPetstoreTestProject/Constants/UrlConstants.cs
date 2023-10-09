namespace SwaggerPetstoreTestProject.Constants
{
    internal class UrlConstants
    {
        internal const string BaseUrl = "https://petstore.swagger.io/v2";

        //pet endpoints
        internal const string AddNewPet = "/pet";
        internal const string FindOrDeletePetById = "/pet/{0}";

        //store endpoints
        internal const string AddNewOrder = "/store/order"; 
        internal const string FindOrDeleteOrderById = "/store/order/{0}";

        //store endpoints
        internal const string AddNewUsersWithList = "/user/createWithList";
        internal const string FindOrDeleteUserByUsername = "/user/{0}";
    }
}