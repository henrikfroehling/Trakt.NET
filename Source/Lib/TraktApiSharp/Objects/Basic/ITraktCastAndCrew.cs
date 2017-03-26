namespace TraktApiSharp.Objects.Basic
{
    using System.Collections.Generic;

    public interface ITraktCastAndCrew
    {
        IEnumerable<ITraktCastMember> Cast { get; set; }

        ITraktCrew Crew { get; set; }
    }
}
