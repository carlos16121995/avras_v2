namespace avras_v2.Domain.Infrastructures.Extensions
{
    public static class EnumExtension
    {
        public static string Name<TEnum>(this TEnum @enum)
            where TEnum : Enum
        {
            var fInfo = @enum.GetType().GetField(@enum.ToString());
            if (fInfo is null) return string.Empty;
            var attrib = (NameAttribute[])fInfo.GetCustomAttributes(typeof(NameAttribute), false);

            if (attrib?.Length > 0)
                return attrib[0].Name;

            else
                return @enum.ToString();
        }
    }
}
