namespace SwaggerPetstoreTestProject.Models
{
    internal class MessageModel
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}