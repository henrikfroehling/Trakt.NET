namespace TraktNet.Enums
{
    /// <summary>Determines the gender of a person.</summary>
    public sealed class TraktGender : TraktEnumeration
    {
        /// <summary>An invalid gender type.</summary>
        public static TraktGender Unspecified { get; } = new TraktGender();

        /// <summary>The male gender.</summary>
        public static TraktGender Male { get; } = new TraktGender(1, "male", "male", "Male");

        /// <summary>The female gender.</summary>
        public static TraktGender Female { get; } = new TraktGender(2, "female", "female", "Female");

        /// <summary>The non binary gender.</summary>
        public static TraktGender NonBinary { get; } = new TraktGender(4, "non_binary", "non_binary", "Non Binary");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktGender" /> class.<para />
        /// The initialized <see cref="TraktGender" /> is invalid.
        /// </summary>
        public TraktGender()
        {
        }

        private TraktGender(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
