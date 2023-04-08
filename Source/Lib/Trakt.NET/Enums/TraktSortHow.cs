namespace TraktNet.Enums
{
    /// <summary>Determines the sort-how type.</summary>
    public sealed class TraktSortHow : TraktEnumeration
    {
        /// <summary>An invalid sort-how type.</summary>
        public static TraktSortHow Unspecified { get; } = new TraktSortHow();

        /// <summary>Determines the sort-how type ordered in ascending order.</summary>
        public static TraktSortHow Ascending { get; } = new TraktSortHow(1, "asc", "asc", "Ascending");

        /// <summary>Determines the sort-how type ordered in descending order.</summary>
        public static TraktSortHow Descending { get; } = new TraktSortHow(2, "desc", "desc", "Descending");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSortHow" /> class.<para />
        /// The initialized <see cref="TraktSortHow" /> is invalid.
        /// </summary>
        public TraktSortHow()
        {
        }

        private TraktSortHow(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
