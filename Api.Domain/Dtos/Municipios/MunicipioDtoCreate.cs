using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Municipios
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome de Municipio é campo Obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome de Município deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE Inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é Campo Obrgatório")]
        public Guid UfId { get; set; }
        
    }
}
