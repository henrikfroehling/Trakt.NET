namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public class TraktPersonMovieCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "production")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "art")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="TraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
