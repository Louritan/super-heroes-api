using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Exception;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Delete
{
    public class DeleteSuperHeroUseCase : IDeleteSuperHeroUseCase
    {
        private readonly ISuperHeroesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSuperHeroUseCase(
            ISuperHeroesWriteOnlyRepository repository,
            IUnitOfWork unitOfWork
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int id)
        {
            var result = await _repository.Delete(id);

            if (!result)
                throw new NotFoundException(ResourceErrorMessages.SUPER_HERO_NOT_FOUND_ERROR);

            await _unitOfWork.Commit();
        }
    }
}
