using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelAPI.Models;
using TravelAPI.Models.Requests;
using TravelAPI.Services;

namespace TravelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        public readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet("tripnotes")]
        public ActionResult<List<TripNote>> GetAllTripNotes(
            GetAllTripNotesRequest request)
        {
            var tripNotes = _tripService.GetFilteredTripNotes(request.Ratings, request.StartDate, request.EndDate);
            return Ok(tripNotes);
        }

        [HttpGet("{Id}")]
        public ActionResult<TripNote> GetTripNoteById(GetTripNoteRequest request)
        {
            var tripNote = _tripService.GetTripNote(request.Id);
            if (tripNote == null)
            {
                return NotFound();
            }
            return Ok(tripNote);
        }

        [HttpPost]
        public ActionResult<TripNote> CreateTripNote(CreateTripNoteRequest request)
        {
            var createdTripNote = _tripService.CreateTripNote(request.Note);
            return CreatedAtAction(nameof(GetTripNoteById), new { id = createdTripNote.Id }, createdTripNote);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateTripNoteById(UpdateTripNoteRequest request)
        {
            var tripNote = _tripService.GetTripNote(request.Id);
            if (tripNote == null)
            {
                return NotFound();
            }

            _tripService.UpdateTripNote(request.Id, request.Note);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteTripNoteById(DeleteTripNoteRequest request)
        {
            var tripNote = _tripService.GetTripNote(request.Id);
            if (tripNote == null)
            {
                return NotFound();
            }

            _tripService.RemoveTripNote(request.Id);
            return NoContent();
        }
    }
}
