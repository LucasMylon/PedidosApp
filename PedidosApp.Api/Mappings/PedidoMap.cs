using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosApp.Api.Entities;

namespace PedidosApp.Api.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDOS");
            builder.HasKey("Id");
            builder.Property(p => p.Id).IsRequired().HasColumnName("ID");
            builder.Property(p => p.NomeCliente).IsRequired().HasColumnName("NOME_CLIENTE").HasMaxLength(150);
            builder.Property(p => p.DataPedido).IsRequired().HasColumnName("DATA_PEDIDO");
            builder.Property(p => p.Valor).IsRequired().HasPrecision(10, 2).HasColumnName("VALOR");
            builder.Property(p => p.Observacoes).IsRequired().HasColumnName("OBSERVACOES").HasMaxLength(250);
        }
    
    }
}
