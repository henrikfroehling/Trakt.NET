namespace TraktNet.Objects.Get.Users
{
    using Basic;

    /// <summary>A collection of ids for a Trakt user.</summary>
    public interface ITraktUserIds : IIds
    {
        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        string Slug { get; set; }

        /// <summary>Gets or sets a globally unique UUID.<para>Nullable</para></summary>
        string UUID { get; set; }
    }
}
