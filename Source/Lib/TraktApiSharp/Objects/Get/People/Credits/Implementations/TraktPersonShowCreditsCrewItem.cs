namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Shows;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonShowCreditsCrewItem : ITraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
