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
    public  class PostListHandler<T> :  IRequestHandler<PostList<T>, string> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public PostListHandler(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
     

        public Task<string> Handle(PostList<T> request, CancellationToken cancellationToken)
        {
            var result = repository.AddRange(request.Obj);
            return Task.FromResult(result);
        }
    }
}
