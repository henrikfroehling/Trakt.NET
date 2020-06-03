namespace TraktNet.Objects.Get.Shows
{
    using System.Collections.Generic;

    /// <summary>Represents a collection of show cast- and crew-members.</summary>
    public class TraktShowCastAndCrew : ITraktShowCastAndCrew
    {
        /// <summary>Gets or sets a list of showcast members. See also <seealso cref="ITraktShowCastMember" />.<para>Nullable</para></summary>
        public IEnumerable<ITraktShowCastMember> Cast { get; set; }

        /// <summary>Gets or sets the show crew members. See also <seealso cref="ITraktShowCrew" />.<para>Nullable</para></summary>
        public ITraktShowCrew Crew { get; set; }
    }
}
