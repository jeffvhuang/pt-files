﻿using FluentValidation;

namespace PTFiles.Application.Features.Consultations.CreateConsultation
{
    public class CreateConsultationCommandValidator : AbstractValidator<CreateConsultationCommand>
    {
        public CreateConsultationCommandValidator()
        {
            RuleFor(v => v.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(v => v.PractitionerId)
                .NotEmpty().WithMessage("Practitioner id is required.");

            RuleFor(v => v.Treatments)
                .NotEmpty().WithMessage("Treatments property is required.");

            RuleFor(v => v.Plans)
                .NotEmpty().WithMessage("Plans property is required.");
        }
    }
}