using avras_v2.Domain.Infrastructures.Extensions;
using System.ComponentModel;

namespace avras_v2.Domain.Enuns.Financials
{
    public enum EChargeType
    {
        [Description("Mensalidade de sócio ou jogador"), Name("Mensalidade")]
        MONTHLYFEE,
        [Description("Aluguel do salão"), Name("Aluguel")]
        RENT,
        [Description("Patrocínio a ser pago"), Name("Patrocínio")]
        SPONSORSHIP,
    }
}
