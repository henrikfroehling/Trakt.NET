namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public class TraktPersonShowCreditsCrew : ITraktPersonShowCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "production")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "art")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="ITraktPersonShowCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<ITraktPersonShowCreditsCrewItem> Editing { get; set; }
    }
}
