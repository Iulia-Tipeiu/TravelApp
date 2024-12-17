using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Models.Requests
{
    public class GetAllTripNotesRequest
    {
        [FromQuery]
        public List<int>? Ratings { get; set; }

        [FromQuery]
        public string? StartDate { get; set; }

        [FromQuery]
        public string? EndDate { get; set; }
    }
}
