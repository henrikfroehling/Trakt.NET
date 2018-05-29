namespace TraktApiSharp.Objects.Get.Users
{
    using System;

    /// <summary>A Trakt user friend.</summary>
    public class TraktUserFriend : ITraktUserFriend
    {
        /// <summary>Gets or sets the UTC datetime, when the relationship began.</summary>
        public DateTime? FriendsAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user friend.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }

        public string Username
        {
            get { return User?.Username; }

            set
            {
                if (User != null)
                    User.Username = value;
            }
        }

        public bool? IsPrivate
        {
            get { return User?.IsPrivate; }

            set
            {
                if (User != null)
                    User.IsPrivate = value;
            }
        }

        public ITraktUserIds Ids
        {
            get { return User?.Ids; }

            set
            {
                if (User != null)
                    User.Ids = value;
            }
        }

        public string Name
        {
            get { return User?.Name; }

            set
            {
                if (User != null)
                    User.Name = value;
            }
        }

        public bool? IsVIP
        {
            get { return User?.IsVIP; }

            set
            {
                if (User != null)
                    User.IsVIP = value;
            }
        }

        public bool? IsVIP_EP
        {
            get { return User?.IsVIP_EP; }

            set
            {
                if (User != null)
                    User.IsVIP_EP = value;
            }
        }

        public DateTime? JoinedAt
        {
            get { return User?.JoinedAt; }

            set
            {
                if (User != null)
                    User.JoinedAt = value;
            }
        }

        public string Location
        {
            get { return User?.Location; }

            set
            {
                if (User != null)
                    User.Location = value;
            }
        }

        public string About
        {
            get { return User?.About; }

            set
            {
                if (User != null)
                    User.About = value;
            }
        }

        public string Gender
        {
            get { return User?.Gender; }

            set
            {
                if (User != null)
                    User.Gender = value;
            }
        }

        public int? Age
        {
            get { return User?.Age; }

            set
            {
                if (User != null)
                    User.Age = value;
            }
        }

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
