namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Shows;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonShowCreditsCastItem : ITraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
