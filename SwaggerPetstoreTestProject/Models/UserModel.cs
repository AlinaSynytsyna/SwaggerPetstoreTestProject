namespace SwaggerPetstoreTestProject.Models
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string? Username { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string? FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string? LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string? Phone { get; set; }

        [JsonProperty(PropertyName = "userStatus")]
        public int UserStatus { get; set; }
    }
}