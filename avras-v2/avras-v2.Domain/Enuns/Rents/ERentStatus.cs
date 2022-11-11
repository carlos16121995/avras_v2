using avras_v2.Domain.Infrastructures.Extensions;
using System.ComponentModel;

namespace avras_v2.Domain.Enuns.Rents
{
    public enum ERentStatus
    {
        [Description("Reserva aguardando aprovação"), Name("Pendente")]
        PENDING,
        [Description("Reserva aprovada"), Name("Aprovada")]
        APPROVED,
        [Description("Reserva cancelada"), Name("Cancelada")]
        CANCELED,
        [Description("Reserva não aprovada"), Name("Recusada")]
        REFUSED,
    }
}
