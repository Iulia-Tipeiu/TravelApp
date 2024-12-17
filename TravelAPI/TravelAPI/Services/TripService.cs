using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using TravelAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using TravelAPI.Settings;

namespace TravelAPI.Services
{
    public class TripService : ITripService
    {
        private readonly IMongoCollection<TripNote> _tripNotes;

        public TripService(IOptions<MongoDBSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _tripNotes = database.GetCollection<TripNote>("TripNote");
        }

        public List<TripNote> GetAllTripNotes()
        {
            return _tripNotes.Find(tripNote => true).ToList();
        }

        public TripNote GetTripNote(string id)
        {
            return _tripNotes.Find(tripNote => tripNote.Id == id).FirstOrDefault();
        }

        public TripNote CreateTripNote(TripNote tripNote)
        {
            tripNote.Id = Guid.NewGuid().ToString();
            _tripNotes.InsertOne(tripNote);
            return tripNote;
        }

        public void UpdateTripNote(string id, TripNote tripNoteIn)
        {
            tripNoteIn.Id = id;
            var filter = Builders<TripNote>.Filter.Eq(r => r.Id, id);
            _tripNotes.ReplaceOne(filter, tripNoteIn);
        }

        public void RemoveTripNote(string id)
        {
            _tripNotes.DeleteOne(tripNote => tripNote.Id == id);
        }

        public List<TripNote> GetFilteredTripNotes(List<int> ratings, string startDate, string endDate)
        {
            var filteredNotes = _tripNotes.AsQueryable();

            if (ratings != null && ratings.Any())
            {
                filteredNotes = filteredNotes.Where(note => ratings.Contains(note.Rating));
            }

            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out var start))
            {
                filteredNotes = filteredNotes.Where(note => note.DateFrom >= start);
            }

            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out var end))
            {
                filteredNotes = filteredNotes.Where(note => note.DateTo <= end);
            }

            return filteredNotes.ToList();
        }
    }
}
