namespace SwaggerPetstoreTestProject.Models
{
    public class Category
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
    }

    public class Tag
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
    }

    public class PetModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "category")]
        public Category? Category { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "photoUrls")]
        public List<string>? PhotoUrls { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<Tag>? Tags { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string? Status { get; set; }
    }
}