namespace TraktNet.Enums
{
    public sealed class TraktDateFormat : TraktEnumeration
    {
        /// <summary>An invalid date format.</summary>
        public static TraktDateFormat Unspecified { get; } = new TraktDateFormat();

        /// <summary>The date format for Month Day Year.</summary>
        public static TraktDateFormat MonthDayYear { get; } = new TraktDateFormat(1, "mdy", "mdy", "Month Day Year");

        /// <summary>The date format for Day Month Year.</summary>
        public static TraktDateFormat DayMonthYear { get; } = new TraktDateFormat(2, "dmy", "dmy", "Day Month Year");

        /// <summary>The date format for Year Month Day.</summary>
        public static TraktDateFormat YearMonthDay { get; } = new TraktDateFormat(4, "ymd", "ymd", "Year Month Day");

        /// <summary>The date format for Year Day Month.</summary>
        public static TraktDateFormat YearDayMonth { get; } = new TraktDateFormat(8, "ydm", "ydm", "Year Day Month");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktDateFormat" /> class.<para />
        /// The initialized <see cref="TraktDateFormat" /> is invalid.
        /// </summary>
        public TraktDateFormat()
        {
        }

        private TraktDateFormat(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
