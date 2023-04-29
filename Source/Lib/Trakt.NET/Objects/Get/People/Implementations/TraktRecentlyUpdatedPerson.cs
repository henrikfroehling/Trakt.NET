namespace TraktNet.Objects.Get.People
{
    using System;

    /// <summary>An updated Trakt person.</summary>
    public class TraktRecentlyUpdatedPerson : ITraktRecentlyUpdatedPerson
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Person" /> was updated.</summary>
        public DateTime? RecentlyUpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt person. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        public ITraktPerson Person { get; set; }

        public string Name
        {
            get => Person?.Name;

            set
            {
                if (Person != null)
                    Person.Name = value;
            }
        }

        public ITraktPersonIds Ids
        {
            get => Person?.Ids;

            set
            {
                if (Person != null)
                    Person.Ids = value;
            }
        }

        public string Biography
        {
            get => Person?.Biography;

            set
            {
                if (Person != null)
                    Person.Biography = value;
            }
        }

        public DateTime? Birthday
        {
            get => Person?.Birthday;

            set
            {
                if (Person != null)
                    Person.Birthday = value;
            }
        }

        public DateTime? Death
        {
            get => Person?.Death;

            set
            {
                if (Person != null)
                    Person.Death = value;
            }
        }

        public int Age => Person != null ? Person.Age : 0;

        public string Birthplace
        {
            get => Person?.Birthplace;

            set
            {
                if (Person != null)
                    Person.Birthplace = value;
            }
        }

        public string Homepage
        {
            get => Person?.Homepage;

            set
            {
                if (Person != null)
                    Person.Homepage = value;
            }
        }

        public string Gender
        {
            get => Person?.Gender;

            set
            {
                if (Person != null)
                    Person.Gender = value;
            }
        }

        public string KnownForDepartment
        {
            get => Person?.KnownForDepartment;

            set
            {
                if (Person != null)
                    Person.KnownForDepartment = value;
            }
        }

        public ITraktPersonSocialIds SocialIds
        {
            get => Person?.SocialIds;

            set
            {
                if (Person != null)
                    Person.SocialIds = value;
            }
        }

        public DateTime? UpdatedAt
        {
            get => Person?.UpdatedAt;

            set
            {
                if (Person != null)
                    Person.UpdatedAt = value;
            }
        }
    }
}
