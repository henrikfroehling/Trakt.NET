namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of ids for a Trakt user.</summary>
    public class TraktUserIds : ITraktUserIds
    {
        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        public string Slug { get; set; }

        /// <summary>Gets or sets a globally unique UUID.<para>Nullable</para></summary>
        public string UUID { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        public bool HasAnyId => !string.IsNullOrEmpty(Slug) || !string.IsNullOrEmpty(UUID);

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            if (!string.IsNullOrEmpty(UUID))
                return UUID;

            return string.Empty;
        }
    }
}
