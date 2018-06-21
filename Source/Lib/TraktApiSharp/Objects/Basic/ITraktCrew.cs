namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    public interface ITraktCrew
    {
        IEnumerable<ITraktCrewMember> Production { get; set; }

        IEnumerable<ITraktCrewMember> Art { get; set; }

        IEnumerable<ITraktCrewMember> Crew { get; set; }

        IEnumerable<ITraktCrewMember> CostumeAndMakeup { get; set; }

        IEnumerable<ITraktCrewMember> Directing { get; set; }

        IEnumerable<ITraktCrewMember> Writing { get; set; }

        IEnumerable<ITraktCrewMember> Sound { get; set; }

        IEnumerable<ITraktCrewMember> Camera { get; set; }

        IEnumerable<ITraktCrewMember> Lighting { get; set; }

        IEnumerable<ITraktCrewMember> VisualEffects { get; set; }

        IEnumerable<ITraktCrewMember> Editing { get; set; }
    }
}
