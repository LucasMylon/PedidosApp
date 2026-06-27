using MediatR;
using PedidosApp.Api.Models;

namespace PedidosApp.Api.Notifications
{
    public class PedidoNotification : INotification
    {
        public Pedidos? Pedidos { get; set; }
        public ActionNotification Action { get; set; }
    }

    public enum ActionNotification
    {
        Create = 1,
        Update = 2,
        Delete = 3
    }
}
