using FluentValidation.TestHelper;
using TravelAPI.Models;
using TravelAPI.Models.Validators;

namespace TravelAPITests.UnitTests
{
    public class TripNoteValidatorTests
    {
        private readonly TripNoteValidator _validator;

        public TripNoteValidatorTests()
        {
            _validator = new TripNoteValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Have_Error_When_Id_Is_Invalid(string id)
        {
            var model = new TripNote { Id = id };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Have_Error_When_Place_Is_Invalid(string place)
        {
            var model = new TripNote { Place = place };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Place);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void Should_Have_Error_When_Rating_Is_Out_Of_Range(int rating)
        {
            var model = new TripNote { Rating = rating };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Rating);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Description with numbers 123")]
        public void Should_Have_Error_When_Description_Is_Invalid(string description)
        {
            var model = new TripNote { Description = description };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Should_Have_Error_When_DateFrom_Is_After_DateTo()
        {
            var model = new TripNote { DateFrom = new DateTime(2024, 12, 31), DateTo = new DateTime(2024, 12, 30) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DateFrom);
        }

        [Fact]
        public void Should_Have_Error_When_DateTo_Is_Before_DateFrom()
        {
            var model = new TripNote { DateFrom = new DateTime(2024, 12, 31), DateTo = new DateTime(2024, 12, 30) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DateTo);
        }

        [Fact]
        public void Should_Not_Have_Error_When_TripNote_Is_Valid()
        {
            var model = new TripNote
            {
                Id = "1",
                Place = "Paris",
                Rating = 5,
                Description = "Trip to Paris",
                DateFrom = new DateTime(2024, 01, 01),
                DateTo = new DateTime(2024, 01, 10)
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
