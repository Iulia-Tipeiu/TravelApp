using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Models.Requests
{
    public class GetTripNoteRequest
    {
        [FromRoute]
        public string Id { get; set; }

    }
}
