using AutoMapper;
using Data.Repositry;
using Domain.Dto;
using Domain.Models;

namespace Api.Mapper
{
    public class MappingProfiles : Profile
    {
        UserRepository F = new UserRepository();
        fillialerepository repository = new fillialerepository();
        public MappingProfiles()
        {
            CreateMap<FunctionofUser, FunctionofUserDto>()
                .ForMember(des => des.NameFunction, i => i.MapFrom(src => src.Function.Name))
                .ForMember(des => des.LabelFunction, i => i.MapFrom(src => src.Function.Label))
                .ForMember(des => des.FillialeName, i => i.MapFrom(src =>
               F.GetuserById(src.Fk_User).filliale))
                .ForMember(des => des.username, i => i.MapFrom(src =>
               F.GetuserById(src.Fk_User).UserName)).
              //  ForMember(des => des.FillialeName, i => i.MapFrom(src =>
              //repository.getsubsidiarybyid(src.Fk_User).FillialeName)).
                 ReverseMap();

            CreateMap<CategoryFunction, CategoryFunctionDto>()
                .ForMember(des => des.Categorytype, i => i.MapFrom(src => src.Category.Categorytype))

                .ForMember(des => des.FunctionLabel, i => i.MapFrom(src => src.Function.Label))
                .ForMember(des => des.Fk_Function, i => i.MapFrom(src => src.Function.IdFunction))
                .ForMember(des => des.FunctionName, i => i.MapFrom(src => src.Function.Name))
                .ForMember(des => des.CategoryId, i => i.MapFrom(src => src.Category.CategoryId))
                 .ForMember(des => des.Fk_Function, i => i.MapFrom(src =>src.Function.IdFunction))
                .ReverseMap();
            CreateMap<typerequestCatg, typeRequestCatgDto>()
                .ForMember(des => des.typerequestCatgID, i => i.MapFrom(src => src.typerequestCatgID))
                .ForMember(des => des.Fk_CategoryId, i => i.MapFrom(src => src.Fk_CategoryId))
                .ForMember(des => des.Categorietype, i => i.MapFrom(src => src.Category.Categorytype))
                .ForMember(des => des.RequestTypeName, i => i.MapFrom(src => src.typeRequest.RequestTypeName))
                .ReverseMap();



            CreateMap<Request, RequestDto>()
                .ForMember(des => des.Organisme, i => i.MapFrom(src => src.Organisme.Name))
                .ForMember(des => des.status, i => i.MapFrom(i => i.state))
                 .ForMember(des => des.Filliale, i => i.MapFrom(src => F.GetuserById(src.Fk_User).filliale))

                 .ForMember(des => des.requesttype, i => i.MapFrom(i => i.RequestType.RequestTypeName))
                 .ForMember(des => des.username, i => i.MapFrom(src =>
                F.GetuserById(src.Fk_User).UserName))
              .ReverseMap();
            }
        }
    }
