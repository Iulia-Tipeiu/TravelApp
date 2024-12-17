using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using TravelAPI.Controllers;
using TravelAPI.Models;
using TravelAPI.Models.Requests;
using TravelAPI.Services;
using Xunit;

namespace TravelAPITests.UnitTests
{
    public class TripControllerTests
    {
        private readonly Mock<TripService> _mockTripService;
        private readonly TripController _tripController;

        public TripControllerTests()
        {
            _mockTripService = new Mock<TripService>();
            _tripController = new TripController(_mockTripService.Object);
        }

        [Fact]
        public void GetAllTripNotes_ReturnsOkResult_WithListOfTripNotes()
        {
            var request = new GetAllTripNotesRequest
            {
                Ratings = new List<int> { 1, 2, 3 },
                StartDate = "2024, 01, 01",
                EndDate = "2024, 12, 31"
            };

            var tripNotes = new List<TripNote>
            {
                new TripNote { Id = "1", Place = "Paris", Rating = 5, Description = "Trip to Paris", DateFrom = new DateTime(2024, 01, 01), DateTo = new DateTime(2024, 01, 10) },
                new TripNote { Id = "2", Place = "London", Rating = 4, Description = "Trip to London", DateFrom = new DateTime(2024, 02, 01), DateTo = new DateTime(2024, 02, 10) }
            };

            _mockTripService.Setup(service => service.GetFilteredTripNotes(request.Ratings, request.StartDate, request.EndDate))
                .Returns(tripNotes);

            var actionResult = _tripController.GetAllTripNotes(request);

            var result = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<TripNote>>(result.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}
