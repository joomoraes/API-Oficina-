using AutoMapper;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
            .ReverseMap();

            CreateMap<UfModel, UfEntity>()
            .ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>()
            .ReverseMap();

            CreateMap<CepModel, CepEntity>()
            .ReverseMap();
        }
    }
}
