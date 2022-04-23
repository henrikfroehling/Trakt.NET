namespace TraktNet.Objects.Get.People
{
    /// <summary>A collection of social ids for various web services for a Trakt person.</summary>
    public interface ITraktPersonSocialIds
    {
        /// <summary>Gets or sets the Twitter Id of a person.<para>Nullable</para></summary>
        string Twitter { get; set; }

        /// <summary>Gets or sets the Facebook Id of a person.<para>Nullable</para></summary>
        string Facebook { get; set; }

        /// <summary>Gets or sets the Instagram Id of a person.<para>Nullable</para></summary>
        string Instagram { get; set; }

        /// <summary>Gets or sets the Wikipedia link of a person.<para>Nullable</para></summary>
        string Wikipedia { get; set; }
    }
}
