namespace TraktApiSharp.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    public interface ITraktPersonMovieCreditsCrew
    {
        IEnumerable<ITraktPersonMovieCreditsCrewItem> Production { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Art { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Crew { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Directing { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Writing { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Sound { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Camera { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        IEnumerable<ITraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
