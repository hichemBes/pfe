using Domain.Interface;
using Domain.Quieres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class GetGenericQueryByIdHandler<T> : IRequestHandler<GetGenericQueryById<T>, T> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public GetGenericQueryByIdHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;

        }
        public Task<T> Handle(GetGenericQueryById<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
