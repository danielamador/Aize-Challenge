using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NUnitTestProject1
{
    public class User
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("userStatus")]
        public int UserStatus { get; set; }
    }
}
