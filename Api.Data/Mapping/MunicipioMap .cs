using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class MunicipioMap:IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CodIBGE);

            builder.HasOne(u => u.Uf)
            .WithMany(m => m.Municipios);
        }
    }
}
