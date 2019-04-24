namespace TraktNet.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public interface ITraktPersonShowCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPersonShowCreditsCrewItem> Editing { get; set; }
    }
}
