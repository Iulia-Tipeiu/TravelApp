using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TravelAPI.Models
{

    public class TripNote
    {
        [BsonId]
        public string? Id { get; set; }

        public string Place { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
