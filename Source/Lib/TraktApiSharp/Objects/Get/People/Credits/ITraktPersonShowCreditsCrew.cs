namespace TraktApiSharp.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    public interface ITraktPersonShowCreditsCrew
    {
        IEnumerable<ITraktPersonShowCreditsCrewItem> Production { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Art { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Crew { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> CostumeAndMakeup { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Directing { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Writing { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Sound { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Camera { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Lighting { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> VisualEffects { get; set; }

        IEnumerable<ITraktPersonShowCreditsCrewItem> Editing { get; set; }
    }
}
