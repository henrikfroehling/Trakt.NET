namespace TraktNet.Objects.Basic
{
    using Get.People;
    using System.Collections.Generic;

    /// <summary>A Trakt cast member.</summary>
    public class TraktCastMember : ITraktCastMember
    {
        /// <summary>Gets or sets the characters collection of the cast member.<para>Nullable</para></summary>
        public IEnumerable<string> Characters { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        public ITraktPerson Person { get; set; }
    }
}
