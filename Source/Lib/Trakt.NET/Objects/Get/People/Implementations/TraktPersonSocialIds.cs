namespace TraktNet.Objects.Get.People
{
    /// <summary>A collection of social ids for various web services for a Trakt person.</summary>
    public class TraktPersonSocialIds : ITraktPersonSocialIds
    {
        /// <summary>Gets or sets the Twitter Id of a person.<para>Nullable</para></summary>
        public string Twitter { get; set; }

        /// <summary>Gets or sets the Facebook Id of a person.<para>Nullable</para></summary>
        public string Facebook { get; set; }

        /// <summary>Gets or sets the Instagram Id of a person.<para>Nullable</para></summary>
        public string Instagram { get; set; }

        /// <summary>Gets or sets the Wikipedia link of a person.<para>Nullable</para></summary>
        public string Wikipedia { get; set; }
    }
}
