using System;

namespace Api.Domain.Dtos.Municipios
{
    public class MunicipioDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public DateTime CreateAt { get; set; }
        
    }
}
