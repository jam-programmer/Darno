using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Application.Common.Extension;
public static class Common
{
    private static readonly char[] Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static readonly char[] Numbers = "0123456789".ToCharArray();
    public static string GetEnumShortName(this Enum item)
    {
        FieldInfo? FieldInfo = item.GetType().GetField(item.ToString());
        DisplayAttribute? attribute = FieldInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? attribute.ShortName! : item.ToString();
    }
    
    public static string GetEnumName(this Enum item)
    {
        FieldInfo? FieldInfo = item.GetType().GetField(item.ToString());
        DisplayAttribute? attribute = FieldInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? attribute.Name! : item.ToString();
    }
    public static int GetEnumNameParseInt(this Enum item)
    {
        FieldInfo? FieldInfo = item.GetType().GetField(item.ToString());
        DisplayAttribute? attribute = FieldInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? int.Parse(attribute.Name!):503;
    }

    public static string GenerateRandomString(int length = 8)
    {
        var random = new Random();
        int numberPosition = random.Next(length);
        int numberValue = random.Next(Numbers.Length);
        var result = Enumerable.Range(0, length)
            .Select(i => i == numberPosition ? Numbers[numberValue].ToString() :
                        Letters[random.Next(Letters.Length)].ToString())
            .ToArray();

        return result.ToString()!;
    }
}
