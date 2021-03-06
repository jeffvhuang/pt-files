﻿using AutoMapper;
using MediatR;
using PTFiles.Application.Common.Extensions;
using PTFiles.Application.Common.Interfaces.Persistence;
using PTFiles.Application.Common.Models;
using PTFiles.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PTFiles.Application.Features.Consultations.UpdateConsultation
{
    public class UpdateConsultationCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PractitionerId { get; set; }
        public int CasefileId { get; set; }
        public SubjectiveAssessmentVm? SubjectiveAssessment { get; set; }
        public ObjectiveAssessmentVm? ObjectiveAssessment { get; set; }
        public string Treatments { get; set; }
        public string Plans { get; set; }

        public class UpdateConsultationCommandHandler : IRequestHandler<UpdateConsultationCommand>
        {
            private readonly IPTFilesDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateConsultationCommandHandler(IPTFilesDbContext context, IMapper mapper)
            {
                _dbContext = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateConsultationCommand command, CancellationToken cancelToken)
            {
                var consultation = await _dbContext.Consultations
                    .Where(c => c.Id == command.Id)
                    .FirstOrNotFoundAsync(nameof(Consultation), command.Id, cancelToken);
                
                consultation.Date = command.Date;
                consultation.PractitionerId = command.PractitionerId;
                consultation.CasefileId = command.CasefileId;

                if (command.SubjectiveAssessment != null)
                {
                    consultation.SubjectiveAssessment = _mapper.Map<SubjectiveAssessment>(command.SubjectiveAssessment);
                }

                if (command.ObjectiveAssessment != null)
                {
                    consultation.ObjectiveAssessment = _mapper.Map<ObjectiveAssessment>(command.ObjectiveAssessment);
                }

                // Objective changed here
                consultation.Treatments = command.Treatments;
                consultation.Plans = command.Plans;

                _dbContext.Consultations.Update(consultation);
                await _dbContext.SaveChangesAsync(cancelToken);

                return Unit.Value;
            }
        }
    }
}
