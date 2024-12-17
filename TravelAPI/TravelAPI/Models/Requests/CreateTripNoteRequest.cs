using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Models.Requests
{
    public class CreateTripNoteRequest
    {
        [FromBody]
        public TripNote Note { get; set; }
    }
}
