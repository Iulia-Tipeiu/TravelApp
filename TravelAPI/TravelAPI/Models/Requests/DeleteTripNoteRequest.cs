using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Models.Requests
{
    public class DeleteTripNoteRequest
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
