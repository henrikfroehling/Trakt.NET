namespace TraktNet.Objects.Basic
{
    using Get.People;
    using System.Collections.Generic;

    /// <summary>A Trakt crew member.</summary>
    public class TraktCrewMember : ITraktCrewMember
    {
        /// <summary>Gets or sets the jobs collection of the crew member.<para>Nullable</para></summary>
        public IList<string> Jobs { get; set; }

        /// <summary>Gets or sets the crew member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        public ITraktPerson Person { get; set; }
    }
}
