using AutoMapper;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.Municipios;
using Api.Domain.Dtos.CEP;
using Api.Domain.Municipios;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
            .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfDto>()
            .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDto>()
            .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCreate>()
            .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>()
            .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepModel, CepDto>()
            .ReverseMap();
            CreateMap<CepModel, CepDtoCreate>()
            .ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>()
            .ReverseMap();
            #endregion
        }
    }
}
