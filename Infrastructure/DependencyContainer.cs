using Data.Repositry;
using Domain.Commands;
using Domain.Handler;
using Domain.Interface;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
           
            services.AddTransient<IGenericRepository<Function>, Repository<Function>>();
            services.AddTransient<IGenericRepository<FunctionofUser>, Repository<FunctionofUser>>();
           
            services.AddTransient<IGenericRepository<Category>, Repository<Category>>();
            services.AddTransient<IGenericRepository<Organisme>, Repository<Organisme>>();
            services.AddTransient<IGenericRepository<Request>, Repository<Request>>();
          
            services.AddTransient<IGenericRepository<typeRequest>, Repository<typeRequest>>();
            services.AddTransient<IGenericRepository<CategoryFunction>, Repository<CategoryFunction>>();
            services.AddTransient<IGenericRepository<typerequestCatg>, Repository<typerequestCatg>>();
            services.AddTransient<IGenericRepository<PieceJoint>, Repository<PieceJoint>>();
            
            #region Request


            services.AddTransient<IRequestHandler<GetAllGenericQuery<Request>, IEnumerable<Request>>, GetAllGenericHandler<Request>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<Request>, Request>, GetGenericQueryByIdHandler<Request>>();
            services.AddTransient<IRequestHandler<PostId<Request>, Request>, PostIdGenericHandler<Request>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Request>, string>, DeleteGenericHandler<Request>>();
            services.AddTransient<IRequestHandler<PutGeneric<Request>, string>, PutGenericHandler<Request>>();
            services.AddTransient<IRequestHandler<PostGeneric<Request>, string>, PostGenericHandler<Request>>();
            #endregion
            #region typeRequest
            services.AddTransient<IRequestHandler<GetAllGenericQuery<typeRequest>, IEnumerable<typeRequest>>, GetAllGenericHandler<typeRequest>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<typeRequest>, typeRequest>, GetGenericQueryByIdHandler<typeRequest>>();
            services.AddTransient<IRequestHandler<PostGeneric<typeRequest>, string>, PostGenericHandler<typeRequest>>();
            services.AddTransient<IRequestHandler<PutGeneric<typeRequest>, string>, PutGenericHandler<typeRequest>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<typeRequest>, string>, DeleteGenericHandler<typeRequest>>();
            services.AddTransient<IRequestHandler<PostId<typeRequest>, typeRequest>, PostIdGenericHandler<typeRequest>>();
            #endregion

            #region PieceJoint
            services.AddTransient<IRequestHandler<GetAllGenericQuery<PieceJoint>, IEnumerable<PieceJoint>>, GetAllGenericHandler<PieceJoint>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<PieceJoint>, PieceJoint>, GetGenericQueryByIdHandler<PieceJoint>>();
            services.AddTransient<IRequestHandler<PostGeneric<PieceJoint>, string>, PostGenericHandler<PieceJoint>>();
            services.AddTransient<IRequestHandler<PutGeneric<PieceJoint>, string>, PutGenericHandler<PieceJoint>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<PieceJoint>, string>, DeleteGenericHandler<PieceJoint>>();
            services.AddTransient<IRequestHandler<PostId<PieceJoint>, PieceJoint>, PostIdGenericHandler<PieceJoint>>();
            #endregion
            #region Organisme
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Organisme>, IEnumerable<Organisme>>, GetAllGenericHandler<Organisme>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<Organisme>, Organisme>, GetGenericQueryByIdHandler<Organisme>>();
            services.AddTransient<IRequestHandler<PostGeneric<Organisme>, string>, PostGenericHandler<Organisme>>();
            services.AddTransient<IRequestHandler<PutGeneric<Organisme>, string>, PutGenericHandler<Organisme>>();
            services.AddTransient<IRequestHandler<DeleteGeneric<Organisme>, string>, DeleteGenericHandler<Organisme>>();
            services.AddTransient<IRequestHandler<PostId<Organisme>, Organisme>, PostIdGenericHandler<Organisme>>();
            #endregion
            #region Function 
            services.AddTransient<IRequestHandler<DeleteGeneric<Function>, string>, DeleteGenericHandler<Function>>();
            services.AddTransient<IRequestHandler<PostId<Function>, Function>, PostIdGenericHandler<Function>>();
            services.AddTransient<IRequestHandler<PutGeneric<Function>, string>, PutGenericHandler<Function>>();
            services.AddTransient<IRequestHandler<PostGeneric<Function>, string>, PostGenericHandler<Function>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<Function>, Function>, GetGenericQueryByIdHandler<Function>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Function>, IEnumerable<Function>>, GetAllGenericHandler<Function>>();
            #endregion
            #region FunctionofUser
            services.AddTransient<IRequestHandler<DeleteGeneric<FunctionofUser>, string>, DeleteGenericHandler<FunctionofUser>>();
            services.AddTransient<IRequestHandler<PostId<FunctionofUser>, FunctionofUser>, PostIdGenericHandler<FunctionofUser>>();
            services.AddTransient<IRequestHandler<PutGeneric<FunctionofUser>, string>, PutGenericHandler<FunctionofUser>>();
            services.AddTransient<IRequestHandler<PostGeneric<FunctionofUser>, string>, PostGenericHandler<FunctionofUser>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<FunctionofUser>, FunctionofUser>, GetGenericQueryByIdHandler<FunctionofUser>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<FunctionofUser>, IEnumerable<FunctionofUser>>, GetAllGenericHandler<FunctionofUser>>();
            #endregion
            #region

            services.AddTransient<IRequestHandler<DeleteGeneric<Category>, string>, DeleteGenericHandler<Category>>();
            services.AddTransient<IRequestHandler<PostId<Category>, Category>, PostIdGenericHandler<Category>>();
            services.AddTransient<IRequestHandler<PutGeneric<Category>, string>, PutGenericHandler<Category>>();
            services.AddTransient<IRequestHandler<PostGeneric<Category>, string>, PostGenericHandler<Category>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<Category>, Category>, GetGenericQueryByIdHandler<Category>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<Category>, IEnumerable<Category>>, GetAllGenericHandler<Category>>();
            #endregion
            #region

            services.AddTransient<IRequestHandler<DeleteGeneric<typerequestCatg>, string>, DeleteGenericHandler<typerequestCatg>>();
            services.AddTransient<IRequestHandler<PostId<typerequestCatg>, typerequestCatg>, PostIdGenericHandler<typerequestCatg>>();
            services.AddTransient<IRequestHandler<PutGeneric<typerequestCatg>, string>, PutGenericHandler<typerequestCatg>>();
            services.AddTransient<IRequestHandler<PostGeneric<typerequestCatg>, string>, PostGenericHandler<typerequestCatg>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<typerequestCatg>, typerequestCatg>, GetGenericQueryByIdHandler<typerequestCatg>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<typerequestCatg>, IEnumerable<typerequestCatg>>, GetAllGenericHandler<typerequestCatg>>();
            #endregion
            #region CategoryFunction

            services.AddTransient<IRequestHandler<DeleteGeneric<CategoryFunction>, string>, DeleteGenericHandler<CategoryFunction>>();
            services.AddTransient<IRequestHandler<PostId<CategoryFunction>, CategoryFunction>, PostIdGenericHandler<CategoryFunction>>();
            services.AddTransient<IRequestHandler<PutGeneric<CategoryFunction>, string>, PutGenericHandler<CategoryFunction>>();
            services.AddTransient<IRequestHandler<PostGeneric<CategoryFunction>, string>, PostGenericHandler<CategoryFunction>>();
            services.AddTransient<IRequestHandler<GetGenericQueryById<CategoryFunction>, CategoryFunction>, GetGenericQueryByIdHandler<CategoryFunction>>();
            services.AddTransient<IRequestHandler<GetAllGenericQuery<CategoryFunction>, IEnumerable<CategoryFunction>>, GetAllGenericHandler<CategoryFunction>>();
            #endregion
        }
    }
}
