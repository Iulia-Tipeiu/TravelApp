using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ITripService
    {
        List<TripNote> GetAllTripNotes();
        TripNote GetTripNote(string id);
        TripNote CreateTripNote(TripNote tripNote);
        void UpdateTripNote(string id, TripNote tripNoteIn);
        void RemoveTripNote(string id);
        List<TripNote> GetFilteredTripNotes(List<int> ratings, string startDate, string endDate);
    }
}
