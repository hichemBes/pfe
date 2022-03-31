using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
  public class PostList<T> : IRequest<string> where T : class
    {
        public List<T> Obj { get; }
        public PostList(List<T> obj)
        {
            Obj = obj;
        }
       

    }
}

