namespace TraktNet.Objects.Get.Lists
{
    using Basic;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt list.</summary>
    public interface ITraktListIds : IIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        uint Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.</summary>
        string Slug { get; set; }
    }
}
