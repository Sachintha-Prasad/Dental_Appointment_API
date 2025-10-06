using Dental.Application.Utilities;

namespace Dental.Application.Features.DentalOffices.Commands.CreateDentalOffices
{
    public class CreateDentalOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
