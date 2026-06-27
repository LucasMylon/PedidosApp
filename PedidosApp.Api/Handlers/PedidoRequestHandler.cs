using MediatR;
using PedidosApp.Api.Commands;
using PedidosApp.Api.Contexts;
using PedidosApp.Api.Entities;

namespace PedidosApp.Api.Handlers
{
    public class PedidoRequestHandler (SqlServerContext context) :
        IRequestHandler<PedidoCreateCommand>,
        IRequestHandler<PedidoUpdateCommand>,
        IRequestHandler<PedidoDeleteCommand>
    {
        public async Task Handle(PedidoCreateCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido
            {
                NomeCliente = request.NomeCliente!,
                Valor = request.Valor,
                Observacoes = request.Observacoes!
            };
            await context.AddAsync(pedido);
            await context.SaveChangesAsync();
        }

        public async Task Handle(PedidoUpdateCommand request, CancellationToken cancellationToken)
        {
            var pedido = await context.Set<Pedido>().FindAsync(request.Id);
            if(pedido == null)
            {
                throw new ApplicationException("Pedido não encontrado para edição");
            }
            
            if(!string.IsNullOrEmpty(request.Nomecliente))
                pedido.NomeCliente = request.Nomecliente;
            
            if(request.DataPedido != null)
                pedido.DataPedido = request.DataPedido.Value;
            
            if(request.Valor != null)
                pedido.Valor = request.Valor.Value;

            if (!string.IsNullOrEmpty(request.Observacoes))
                pedido.Observacoes = request.Observacoes;

            context.Update(pedido);
            await context.SaveChangesAsync();
        }

        public async Task Handle(PedidoDeleteCommand request, CancellationToken cancellationToken)
        {
            var pedido = await context.Set<Pedido>().FindAsync(request.Id);
            if (pedido == null)
            {
                throw new ApplicationException("Pedido não encontrado para exclusão");
            }
            context.Remove(pedido);
            await context.SaveChangesAsync();
        }
    }
}
