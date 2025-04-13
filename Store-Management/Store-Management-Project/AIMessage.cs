using System;
using System.Text.Json.Serialization;

namespace Store_Management_Project
{
    internal class AIMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonIgnore]
        public DateTime Time { get; set; }

        [JsonConstructor]
        AIMessage() { }

        public AIMessage(string role, string content)
        {
            Role = role;
            Content = content;
            Time = DateTime.Now;
        }

        public AIMessage(string role, string content, DateTime time)
        {
            Role = role;
            Content = content;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Role}: {Content}";
        }
    }
}
