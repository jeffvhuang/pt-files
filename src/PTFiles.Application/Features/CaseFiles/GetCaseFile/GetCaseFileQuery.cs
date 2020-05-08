﻿using AutoMapper;
using PTFiles.Application.Common.Extensions;
using PTFiles.Application.Common.Interfaces.Persistence;
using PTFiles.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PTFiles.Application.Features.CaseFiles.GetCaseFile
{
    public class GetCaseFileQuery : IRequest<GetCaseFileVm>
    {
        public int Id { get; set; }

        public class GetCaseFileQueryHandler : IRequestHandler<GetCaseFileQuery, GetCaseFileVm>
        {
            private readonly IPTFilesDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetCaseFileQueryHandler(IPTFilesDbContext context, IMapper mapper)
            {
                _dbContext = context;
                _mapper = mapper;
            }

            public async Task<GetCaseFileVm> Handle(GetCaseFileQuery query, CancellationToken token)
            {
                var file = await _dbContext.CaseFiles
                    .AsNoTracking()
                    .Include(c => c.Consultations)
                    .Include(c => c.Patient)
                    .Where(p => p.Id == query.Id)
                    .FirstOrNotFoundAsync(nameof(CaseFile), query.Id, token);

                return _mapper.Map<GetCaseFileVm>(file);
            }
        }
    }
}