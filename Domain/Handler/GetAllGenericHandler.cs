using Domain.Interface;
using Domain.Quieres;
using MediatR;

using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class GetAllGenericHandler<T> : IRequestHandler<GetAllGenericQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public GetAllGenericHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<IEnumerable<T>> Handle(GetAllGenericQuery<T> request, CancellationToken cancellationToken)
        {
            var result = repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
