namespace TraktApiSharp.Enums
{
    using Objects.Get.Users.Lists;

    /// <summary>Determines the sort order for lists of <see cref="ITraktList" />.</summary>
    public sealed class TraktListSortOrder : TraktEnumeration
    {
        /// <summary>An invalid sort order.</summary>
        public static TraktListSortOrder Unspecified { get; } = new TraktListSortOrder();

        /// <summary>Lists will be sorted by the most popular first.</summary>
        public static TraktListSortOrder Popular { get; } = new TraktListSortOrder(1, "popular", "popular", "Popular");

        /// <summary>Lists will be sorted by the number of likes first.</summary>
        public static TraktListSortOrder Likes { get; } = new TraktListSortOrder(2, "likes", "likes", "Likes");

        /// <summary>Lists will be sorted by the number of comments first.</summary>
        public static TraktListSortOrder Comments { get; } = new TraktListSortOrder(4, "comments", "comments", "Comments");

        /// <summary>Lists will be sorted by the number of items first.</summary>
        public static TraktListSortOrder Items { get; } = new TraktListSortOrder(8, "items", "items", "Items");

        /// <summary>Lists will be sorted by <see cref="ITraktList.CreatedAt" /> first.</summary>
        public static TraktListSortOrder Added { get; } = new TraktListSortOrder(16, "added", "added", "Added");

        /// <summary>Lists will be sorted by <see cref="ITraktList.UpdatedAt" /> first.</summary>
        public static TraktListSortOrder Updated { get; } = new TraktListSortOrder(32, "updated", "updated", "Updated");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListSortOrder" /> class.<para />
        /// The initialized <see cref="TraktListSortOrder" /> is invalid.
        /// </summary>
        public TraktListSortOrder()
        {
        }

        private TraktListSortOrder(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
