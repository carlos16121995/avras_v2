namespace avras_v2.Domain.Infrastructures.Extensions
{
    public class NameAttribute : Attribute
    {
        private readonly string name;

        public NameAttribute(string name) => this.name = name;

        public virtual string Name => name ?? "";
    }
}
