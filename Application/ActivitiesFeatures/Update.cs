using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.ActivitiesFeatures;

public class Update
{
    public record Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public record Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Activity.Id);

            _mapper.Map(request.Activity, activity);
            
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}