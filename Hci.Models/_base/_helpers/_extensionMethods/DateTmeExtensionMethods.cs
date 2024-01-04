namespace Hci.Models;

/// <summary>
///     This is just for the sake of keeping the POCO classes as pure as possible,
///     as this could be a property on the visit class, but in the other hand this could
///     be used in some other dates calculation
/// </summary>
public static class DateTmeExtensionMethods
{
    /// <summary>
    ///     Calculates teh elapsed time between two dates (hours:minutes:seconds)
    /// </summary>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <returns>String containing the elapsed time in hours:minutes:seconds</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string CalculateElapsedTime(this DateTime startDate, DateTime? endDate)
    {
        // this just to show we could put some barriers here. This condition is not to be tested
        if (startDate.Date == endDate)
            throw new ArgumentException($"{nameof(startDate)} cannot be the lowest datetime allowed in the framework!");

        if (endDate == null) return "Still in the building";

        var difference = endDate.Value - startDate;
        var totalDaysToHours = difference.Days * 24;

        var time = string.Empty;
        var hours = difference.Hours + totalDaysToHours;

        if (hours > 0)
            time = hours + (hours > 1 ? " Hours" : " Hour");
        if (difference.Minutes > 0)
            time += (!string.IsNullOrEmpty(time) ? $" and {difference.Minutes}" : $"{difference.Minutes}") + " Minutes";
        return time;
    }
}