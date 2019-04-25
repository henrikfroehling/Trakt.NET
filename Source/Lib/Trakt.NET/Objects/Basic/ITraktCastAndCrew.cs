namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    /// <summary>Represents a collection of cast- and crew-members.</summary>
    public interface ITraktCastAndCrew
    {
        /// <summary>Gets or sets a list of cast members. See also <seealso cref="ITraktCastMember" />.<para>Nullable</para></summary>
        IEnumerable<ITraktCastMember> Cast { get; set; }

        /// <summary>Gets or sets the crew members. See also <seealso cref="ITraktCrew" />.<para>Nullable</para></summary>
        ITraktCrew Crew { get; set; }
    }
}
