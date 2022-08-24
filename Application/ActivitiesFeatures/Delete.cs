using Domain;
using MediatR;
using Persistence;

namespace Application.ActivitiesFeatures;

public class Delete
{
    public record Command : IRequest
    {
        public Guid Id { get; set; }
    }

    public record Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Id);
            _context.Remove(activity);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}