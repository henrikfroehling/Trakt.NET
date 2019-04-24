namespace TraktNet.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user.</summary>
    public interface ITraktUser
    {
        /// <summary>Gets or sets the user's username.<para>Nullable</para></summary>
        string Username { get; set; }

        /// <summary>Gets or sets the user's privacy status.</summary>
        bool? IsPrivate { get; set; }

        /// <summary>Gets or sets the collection of ids for the user. See also <seealso cref="ITraktUserIds" />.<para>Nullable</para></summary>
        ITraktUserIds Ids { get; set; }

        /// <summary>Gets or sets the user's name.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the user's VIP status.</summary>
        bool? IsVIP { get; set; }

        /// <summary>Gets or sets the user's VIP EP status.</summary>
        bool? IsVIP_EP { get; set; }

        /// <summary>Gets or sets the UTC datetime when the user joined Trakt.</summary>
        DateTime? JoinedAt { get; set; }

        /// <summary>Gets or sets the user's location.<para>Nullable</para></summary>
        string Location { get; set; }

        /// <summary>Gets or sets the user's about information.<para>Nullable</para></summary>
        string About { get; set; }

        /// <summary>Gets or sets the user's gender.<para>Nullable</para></summary>
        string Gender { get; set; }

        /// <summary>Gets or sets the user's age.</summary>
        int? Age { get; set; }

        /// <summary>Gets or sets the collection of images for the user. See also <seealso cref="ITraktUserImages" />.<para>Nullable</para></summary>
        ITraktUserImages Images { get; set; }
    }
}
