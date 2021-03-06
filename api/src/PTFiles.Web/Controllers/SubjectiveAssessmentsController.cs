﻿using PTFiles.Application.Features.SubjectiveAx.GetSubjectiveAssessment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PTFiles.Web.Controllers
{
    [ApiController]
    [Route("")]
    public class SubjectiveAssessmentsController : ApiControllerBase
    {
        [HttpGet("consultations/{consultationId}/subjective")]
        public async Task<ActionResult<GetSubjectiveAssessmentVm>> Get(int consultationId)
        {
            return await Mediator.Send(new GetSubjectiveAssessmentQuery { ConsultationId = consultationId });
        }
    }
}
