namespace TraktNet.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    /// <summary>Contains all Trakt shows where a Trakt person is in the cast or crew.</summary>
    public interface ITraktPersonShowCredits
    {
        /// <summary>
        /// Gets or sets a list of cast positions, in which a person is.
        /// See also <seealso cref="ITraktPersonShowCreditsCastItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCastItem> Cast { get; set; }

        /// <summary>
        /// Gets or sets a collection of crew positions, which a person has.
        /// See also <seealso cref="ITraktPersonShowCreditsCrew" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPersonShowCreditsCrew Crew { get; set; }
    }
}
