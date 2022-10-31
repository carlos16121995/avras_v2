using System.ComponentModel;

namespace avras_v2.Domain.Enuns.Patrimonies
{
    using avras_v2.Domain.Infrastructures.Extensions;

    public enum EPatrimonyStatus
    {
        [Description("Aguardando revisão do pedido"), Name("Pendente")]
        PENDING,
        [Description("Solicitação de concessão aprovada"), Name("Aprovada")]
        APPROVED,
        [Description("Solicitação de consseção recusada"), Name("Recusada")]
        REFUSED
    }
}
