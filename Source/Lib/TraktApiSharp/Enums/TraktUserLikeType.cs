namespace TraktApiSharp.Enums
{
    public sealed class TraktUserLikeType : TraktEnumeration
    {
        public static TraktUserLikeType Unspecified { get; } = new TraktUserLikeType();
        public static TraktUserLikeType Comment { get; } = new TraktUserLikeType(1, "comment", "comments", "Comment");
        public static TraktUserLikeType List { get; } = new TraktUserLikeType(2, "list", "lists", "List");

        public TraktUserLikeType() : base() { }

        private TraktUserLikeType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
