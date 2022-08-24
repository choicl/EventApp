using System.Data.Common;
using Domain;
using MediatR;
using Persistence;

namespace Application.ActivitiesFeatures;

public class Details
{
    public record Query : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public record Handler : IRequestHandler<Query, Activity>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);
        }
    }
}