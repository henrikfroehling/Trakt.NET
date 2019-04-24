namespace TraktNet.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user follower.</summary>
    public class TraktUserFollower : ITraktUserFollower
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        public DateTime? FollowedAt { get; set; }

        /// <summary>
        /// Gets or sets the following / followed Trakt user.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }

        /// <summary>Gets or sets the user's username.<para>Nullable</para></summary>
        public string Username
        {
            get { return User?.Username; }

            set
            {
                if (User != null)
                    User.Username = value;
            }
        }

        /// <summary>Gets or sets the user's privacy status.</summary>
        public bool? IsPrivate
        {
            get { return User?.IsPrivate; }

            set
            {
                if (User != null)
                    User.IsPrivate = value;
            }
        }

        /// <summary>Gets or sets the collection of ids for the user. See also <seealso cref="ITraktUserIds" />.<para>Nullable</para></summary>
        public ITraktUserIds Ids
        {
            get { return User?.Ids; }

            set
            {
                if (User != null)
                    User.Ids = value;
            }
        }

        /// <summary>Gets or sets the user's name.<para>Nullable</para></summary>
        public string Name
        {
            get { return User?.Name; }

            set
            {
                if (User != null)
                    User.Name = value;
            }
        }

        /// <summary>Gets or sets the user's VIP status.</summary>
        public bool? IsVIP
        {
            get { return User?.IsVIP; }

            set
            {
                if (User != null)
                    User.IsVIP = value;
            }
        }

        /// <summary>Gets or sets the user's VIP EP status.</summary>
        public bool? IsVIP_EP
        {
            get { return User?.IsVIP_EP; }

            set
            {
                if (User != null)
                    User.IsVIP_EP = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the user joined Trakt.</summary>
        public DateTime? JoinedAt
        {
            get { return User?.JoinedAt; }

            set
            {
                if (User != null)
                    User.JoinedAt = value;
            }
        }

        /// <summary>Gets or sets the user's location.<para>Nullable</para></summary>
        public string Location
        {
            get { return User?.Location; }

            set
            {
                if (User != null)
                    User.Location = value;
            }
        }

        /// <summary>Gets or sets the user's about information.<para>Nullable</para></summary>
        public string About
        {
            get { return User?.About; }

            set
            {
                if (User != null)
                    User.About = value;
            }
        }

        /// <summary>Gets or sets the user's gender.<para>Nullable</para></summary>
        public string Gender
        {
            get { return User?.Gender; }

            set
            {
                if (User != null)
                    User.Gender = value;
            }
        }

        /// <summary>Gets or sets the user's age.</summary>
        public int? Age
        {
            get { return User?.Age; }

            set
            {
                if (User != null)
                    User.Age = value;
            }
        }

        /// <summary>Gets or sets the collection of images for the user. See also <seealso cref="ITraktUserImages" />.<para>Nullable</para></summary>
        public ITraktUserImages Images
        {
            get { return User?.Images; }

            set
            {
                if (User != null)
                    User.Images = value;
            }
        }
    }
}
