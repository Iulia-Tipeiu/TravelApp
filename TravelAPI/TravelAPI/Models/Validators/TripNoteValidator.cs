using FluentValidation;

namespace TravelAPI.Models.Validators
{
    public class TripNoteValidator : AbstractValidator<TripNote>
    {
        public TripNoteValidator()
        {
            RuleFor(validator => validator.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(validator => validator.Place)
                .NotEmpty()
                .NotNull();

            RuleFor(validator => validator.Rating)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");

            RuleFor(validator => validator.Description)
                .NotEmpty()
                .NotNull()
                .Matches(@"^[^\d]*$")
                .WithMessage("Description must not contain numbers.");

            RuleFor(validator => validator.DateFrom)
                .NotEmpty()
                .NotNull()
                .LessThan(validator => validator.DateTo)
                .WithMessage("DateFrom must be before DateTo.");

            RuleFor(validator => validator.DateTo)
                .NotEmpty()
                .NotNull()
                .GreaterThan(validator => validator.DateFrom)
                .WithMessage("DateFrom must be before DateFrom.");

        }
    }
}
