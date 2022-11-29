using System.ComponentModel;

namespace avras_v2.Domain.Enuns.Users
{
    using avras_v2.Domain.Infrastructures.Extensions;

    public enum EUserType 
    {
        [Description("Usuário básico do sistema"), Name("Usuário")]
        USER = 1,
        [Description("Usuário com status de sócio"), Name("Sócio")]
        ASSOCIATE = 2,
        [Description("Usuário com status de jogador"), Name("Jogador")]
        PLAYER = 4
    }
}
