namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of crew members in different categories.</summary>
    public class TraktCrew
    {
        /// <summary>
        /// Gets or sets a list of crew members in the production category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "production")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the art category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "art")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the costume and make-up category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        [Nullable]
        public IEnumerable<TraktCrewMember> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the directing category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the writing category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the sound category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the camera category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the lighting category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the visual effects category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        [Nullable]
        public IEnumerable<TraktCrewMember> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the editing category. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Editing { get; set; }
    }
}
