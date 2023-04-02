namespace TraktNet.Objects.Get.People
{
    using System;

    /// <summary>A Trakt person.</summary>
    public interface ITraktPerson
    {
        /// <summary>Gets or sets the person name.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the person for various web services.
        /// See also <seealso cref="ITraktPersonIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPersonIds Ids { get; set; }

        /// <summary>Gets or sets the biography of the person.<para>Nullable</para></summary>
        string Biography { get; set; }

        /// <summary>Gets or sets the UTC datetime when the person was born.</summary>
        DateTime? Birthday { get; set; }

        /// <summary>Gets or sets the UTC datetime when the person died.</summary>
        DateTime? Death { get; set; }

        /// <summary>Returns the age of the person, if <see cref="Birthday" /> is set, otherwise zero.</summary>
        int Age { get; }

        /// <summary>Gets or sets the birthplace of the person.<para>Nullable</para></summary>
        string Birthplace { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the person.<para>Nullable</para></summary>
        string Homepage { get; set; }

        /// <summary>Gets or sets the gender of the person.<para>Nullable</para></summary>
        string Gender { get; set; }

        /// <summary>Gets or sets the known department of the person.<para>Nullable</para></summary>
        string KnownForDepartment { get; set; }

        /// <summary>
        /// Gets or sets the collection of social ids for the person for various web services.
        /// See also <seealso cref="ITraktPersonSocialIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPersonSocialIds SocialIds { get; set; }

        /// <summary>Gets or sets when the person was lastly updated.<para>Nullable</para></summary>
        DateTime? UpdatedAt { get; set; }
    }
}
