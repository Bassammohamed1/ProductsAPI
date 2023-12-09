using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Category? Category { get; set; }
    }
}
