using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Models.Requests
{
    public class UpdateTripNoteRequest
    {
        [FromRoute]
        public string Id { get; set; }
        [FromBody]
        public TripNote Note { get; set; }
    }
}
