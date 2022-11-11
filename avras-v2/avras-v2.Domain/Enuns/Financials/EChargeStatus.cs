using System.ComponentModel;

namespace avras_v2.Domain.Enuns.Financials
{
    using avras_v2.Domain.Infrastructures.Extensions;

    public enum EChargeStatus
    {
        [Description("Aguardando pagamento da cobrança"), Name("Pendente")]
        PENDING,
        [Description("Cobrança paga com sucesso"), Name("Aprovada")]
        APPROVED,
        [Description("Cobrança cancelada"), Name("Cancelada")]
        CANCELED,
        [Description("Cobrança estornada com sucesso"), Name("Estornada")]
        CHARGEBACK,
    }
}
