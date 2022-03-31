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
    public class PostGenericHandler<T> : IRequestHandler<PostGeneric<T>, string> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public PostGenericHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(PostGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Add(request.Obj);
            return Task.FromResult(result);
        }
    }
}
