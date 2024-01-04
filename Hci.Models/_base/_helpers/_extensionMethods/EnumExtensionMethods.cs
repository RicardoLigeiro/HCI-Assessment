using System.ComponentModel;

namespace Hci.Models;

/// <summary>
///     Enum extension methods
/// </summary>
public static class EnumExtensionMethods
{
    /// <summary>
    ///     Get the description of the enum
    /// </summary>
    /// <param name="source"> Source object </param>
    /// <returns> The description </returns>
    public static string Description(this Enum source)
    {
        var fi = source.GetType().GetField(source.ToString());
        var attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    }
}