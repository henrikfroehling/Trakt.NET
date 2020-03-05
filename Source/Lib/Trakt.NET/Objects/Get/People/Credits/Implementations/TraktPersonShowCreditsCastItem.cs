namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonShowCreditsCastItem : ITraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        public string Character { get; set; }

        /// <summary>Gets or sets the characters collection of the cast position.<para>Nullable</para></summary>
        public IEnumerable<string> Characters { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
