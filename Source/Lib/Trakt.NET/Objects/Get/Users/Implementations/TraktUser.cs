namespace TraktNet.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user.</summary>
    public class TraktUser : ITraktUser
    {
        /// <summary>Gets or sets the user's username.<para>Nullable</para></summary>
        public string Username { get; set; }

        /// <summary>Gets or sets the user's privacy status.</summary>
        public bool? IsPrivate { get; set; }

        /// <summary>Gets or sets the collection of ids for the user. See also <seealso cref="ITraktUserIds" />.<para>Nullable</para></summary>
        public ITraktUserIds Ids { get; set; }

        /// <summary>Gets or sets the user's name.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the user's VIP status.</summary>
        public bool? IsVIP { get; set; }

        /// <summary>Gets or sets the user's VIP EP status.</summary>
        public bool? IsVIP_EP { get; set; }

        /// <summary>Gets or sets the UTC datetime when the user joined Trakt.</summary>
        public DateTime? JoinedAt { get; set; }

        /// <summary>Gets or sets the user's location.<para>Nullable</para></summary>
        public string Location { get; set; }

        /// <summary>Gets or sets the user's about information.<para>Nullable</para></summary>
        public string About { get; set; }

        /// <summary>Gets or sets the user's gender.<para>Nullable</para></summary>
        public string Gender { get; set; }

        /// <summary>Gets or sets the user's age.</summary>
        public int? Age { get; set; }

        /// <summary>Gets or sets the collection of images for the user. See also <seealso cref="ITraktUserImages" />.<para>Nullable</para></summary>
        public ITraktUserImages Images { get; set; }

        /// <summary>Gets or sets the user's VIP OG status.</summary>
        public bool? IsVIP_OG { get; set; }

        /// <summary>Gets or sets the user's VIP years.</summary>
        public int? VIP_Years { get; set; }

        /// <summary>Gets or sets the user's VIP cover image.</summary>
        public string VIP_CoverImage { get; set; }
    }
}
