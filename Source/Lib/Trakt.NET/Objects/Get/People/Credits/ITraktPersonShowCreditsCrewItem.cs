namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public interface ITraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        string Job { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
