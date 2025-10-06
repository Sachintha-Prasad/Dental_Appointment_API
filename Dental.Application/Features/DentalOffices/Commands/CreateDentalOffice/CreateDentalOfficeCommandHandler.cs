using Dental.Application.Contracts.Persistance;
using Dental.Application.Contracts.Repositories;
using Dental.Application.Utilities;
using Dental.Domain.Entities;

namespace Dental.Application.Features.DentalOffices.Commands.CreateDentalOffices
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;

        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            var dentalOffice = new DentalOffice(command.Name);

            try
            {
                var result = await repository.Add(dentalOffice);
                await unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
