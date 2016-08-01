namespace TraktApiSharp.Objects.Basic
{
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
        public IEnumerable<TraktCrewMember> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in an art position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "art")]
        public IEnumerable<TraktCrewMember> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<TraktCrewMember> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a costume and make-up position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<TraktCrewMember> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a directing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<TraktCrewMember> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a writing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<TraktCrewMember> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a sound position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<TraktCrewMember> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a camera position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<TraktCrewMember> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a lighting position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<TraktCrewMember> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in a visual effects position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<TraktCrewMember> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in an editing position. See also <seealso cref="TraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<TraktCrewMember> Editing { get; set; }
    }
}
