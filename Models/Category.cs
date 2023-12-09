using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace TestApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public List<Item>? Item { get; set; }
    }
}
