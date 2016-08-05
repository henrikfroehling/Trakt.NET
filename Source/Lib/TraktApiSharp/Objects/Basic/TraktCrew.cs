namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of crew members of different positions.</summary>
    public class TraktCrew
    {
        /// <summary>
        /// Gets or sets a list of crew members in a production position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "production")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in an art position. See also <seealso cref="TraktCrewMember" />.
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
        /// Gets or sets a list of crew members in a costume and make-up position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        [Nullable]
        public IEnumerable<TraktCrewMember> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a directing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a writing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a sound position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a camera position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a lighting position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a visual effects position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        [Nullable]
        public IEnumerable<TraktCrewMember> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in an editing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        [Nullable]
        public IEnumerable<TraktCrewMember> Editing { get; set; }
    }
}
