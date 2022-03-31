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
    public class PostIdGenericHandler<T> : IRequestHandler<PostId<T>, T> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public PostIdGenericHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;

        }
        public Task<T> Handle(PostId<T> request, CancellationToken cancellationToken)
        {
            var result = repository.AddId(request.Obj);
            return Task.FromResult(result);
        }
    }
}
