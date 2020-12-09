using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using KodiaMagino.Entidades.Ventas;

namespace KodiaMagino.Datos.Mapping.Ventas
{
    public class VentaMap : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("venta")
               .HasKey(v => v.idventa);
            builder.HasOne(v => v.persona)
                .WithMany(p => p.ventas)
                .HasForeignKey(v => v.idcliente);
        }
    }
}


