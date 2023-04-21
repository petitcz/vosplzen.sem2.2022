using System.Text.Json.Serialization;

namespace vosplzen.sem2h1.Data.Dto
{
    public class GenericResponseDto
    {


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Success { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Failed { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
