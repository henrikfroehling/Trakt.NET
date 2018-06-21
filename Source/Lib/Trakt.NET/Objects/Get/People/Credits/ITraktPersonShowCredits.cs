namespace TraktNet.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    public interface ITraktPersonShowCredits
    {
        IEnumerable<ITraktPersonShowCreditsCastItem> Cast { get; set; }

        ITraktPersonShowCreditsCrew Crew { get; set; }
    }
}
