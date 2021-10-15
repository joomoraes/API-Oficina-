using System;

namespace Api.Domain.Dtos.CEP
{
    public class CepDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
