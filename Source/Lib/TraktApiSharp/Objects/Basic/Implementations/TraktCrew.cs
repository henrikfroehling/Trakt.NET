namespace TraktApiSharp.Objects.Basic.Implementations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of crew members in different categories.</summary>
    public class TraktCrew : ITraktCrew
    {
        /// <summary>
        /// Gets or sets a list of crew members in the production category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "production")]
        public IEnumerable<ITraktCrewMember> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the art category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "art")]
        public IEnumerable<ITraktCrewMember> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<ITraktCrewMember> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the costume and make-up category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<ITraktCrewMember> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the directing category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<ITraktCrewMember> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the writing category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<ITraktCrewMember> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the sound category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<ITraktCrewMember> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the camera category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<ITraktCrewMember> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the lighting category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<ITraktCrewMember> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the visual effects category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<ITraktCrewMember> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew members in the editing category. See also <seealso cref="ITraktCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<ITraktCrewMember> Editing { get; set; }
    }
}
