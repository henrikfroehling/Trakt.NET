namespace TraktNet.Objects.Get.People
{
    using Enums;
    using Extensions;
    using System;

    /// <summary>A Trakt person.</summary>
    public class TraktPerson : ITraktPerson
    {
        /// <summary>Gets or sets the person name.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the person for various web services.
        /// See also <seealso cref="ITraktPersonIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPersonIds Ids { get; set; }

        /// <summary>Gets or sets the biography of the person.<para>Nullable</para></summary>
        public string Biography { get; set; }

        /// <summary>Gets or sets the UTC datetime when the person was born.</summary>
        public DateTime? Birthday { get; set; }

        /// <summary>Gets or sets the UTC datetime when the person died.</summary>
        public DateTime? Death { get; set; }

        /// <summary>Returns the age of the person, if <see cref="Birthday" /> is set, otherwise zero.</summary>
        public int Age
        {
            get
            {
                if (Birthday.HasValue)
                {
                    if (Death.HasValue)
                        return Birthday.YearsBetween(Death);

                    return Birthday.YearsBetween(DateTime.Now);
                }

                return 0;
            }
        }

        /// <summary>Gets or sets the birthplace of the person.<para>Nullable</para></summary>
        public string Birthplace { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the person.<para>Nullable</para></summary>
        public string Homepage { get; set; }

        /// <summary>Gets or sets the gender of the person. See also <seealso cref="TraktGender" />.<para>Nullable</para></summary>
        public TraktGender Gender { get; set; }

        /// <summary>Gets or sets the known department of the person.<para>Nullable</para></summary>
        public string KnownForDepartment { get; set; }

        /// <summary>
        /// Gets or sets the collection of social ids for the person for various web services.
        /// See also <seealso cref="ITraktPersonSocialIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPersonSocialIds SocialIds { get; set; }

        /// <summary>Gets or sets when the person was lastly updated.<para>Nullable</para></summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
