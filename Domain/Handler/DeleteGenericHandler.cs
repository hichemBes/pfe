using Domain.Commands;
using Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Handler
{
    public class DeleteGenericHandler<T> : IRequestHandler<DeleteGeneric<T>, string> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public DeleteGenericHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(DeleteGeneric<T> request, CancellationToken cancellationToken)
        {
            var res = repository.Remove(request.Id);
            return Task.FromResult(res);

        }
    }
}
