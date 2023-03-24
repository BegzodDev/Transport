﻿using Transport.Application.Abstractions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.Admin.Commands.Airlines
{
    public class CreateAirlineCommand : ICommand<int>
    {
        public string Flight_From { get; set; } = string.Empty;
        public string Flight_To { get; set; } = string.Empty;  // Flight_For
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int CountBusinessClassPlace { get; set; }
        public int CountEconomyClassPlace { get; set; }
        public int CountVIPClassPlace { get; set; }

    }

    public class CreateAirlineCommandHandler : ICommandHandler<CreateAirlineCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
        {

            var entity = new Airline()
            {
                Flight_From = request.Flight_From,
                Flight_For = request.Flight_To,
                Price = request.Price,
                Date = request.Date,
                Count_Business_Class_Place = request.CountBusinessClassPlace,
                Count_VIP_Class_Place = request.CountVIPClassPlace,
                Count_Econom_Class_Place = request.CountEconomyClassPlace
            };

            await _context.airlines.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
