namespace TraktNet.Objects.Get.Shows
{
    using System.Collections.Generic;

    /// <summary>A collection of show crew members in different categories.</summary>
    public class TraktShowCrew : ITraktShowCrew
    {
        /// <summary>
        /// Gets or sets a list of show crew members in the production category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the art category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the costume and make-up category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the directing category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the writing category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the sound category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the camera category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the lighting category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the visual effects category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of show crew members in the editing category. See also <seealso cref="ITraktShowCrewMember" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktShowCrewMember> Editing { get; set; }
    }
}
