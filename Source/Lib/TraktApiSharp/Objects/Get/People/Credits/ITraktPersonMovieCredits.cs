namespace TraktApiSharp.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    public interface ITraktPersonMovieCredits
    {
        IEnumerable<ITraktPersonMovieCreditsCastItem> Cast { get; set; }

        ITraktPersonMovieCreditsCrew Crew { get; set; }
    }
}
