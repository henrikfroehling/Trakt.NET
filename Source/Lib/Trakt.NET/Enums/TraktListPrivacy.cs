namespace TraktNet.Enums
{
    /// <summary>Determines the privacy of a list.</summary>
    public sealed class TraktListPrivacy : TraktEnumeration
    {
        /// <summary>An invalid privacy type.</summary>
        public static TraktListPrivacy Unspecified { get; } = new TraktListPrivacy();

        /// <summary>The list is private. Only the user who created the list can see it.</summary>
        public static TraktListPrivacy Private { get; } = new TraktListPrivacy(1, "private", "private", "Private");

        /// <summary>The list is only viewable by a shared link.</summary>
        public static TraktListPrivacy Link { get; } = new TraktListPrivacy(2, "link", "link", "Link");

        /// <summary>The list can only be seen by friends.</summary>
        public static TraktListPrivacy Friends { get; } = new TraktListPrivacy(4, "friends", "friends", "Friends");

        /// <summary>The list is public and anyone can see it.</summary>
        public static TraktListPrivacy Public { get; } = new TraktListPrivacy(8, "public", "public", "Public");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListPrivacy" /> class.<para />
        /// The initialized <see cref="TraktListPrivacy" /> is invalid.
        /// </summary>
        public TraktListPrivacy()
        {
        }

        private TraktListPrivacy(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
