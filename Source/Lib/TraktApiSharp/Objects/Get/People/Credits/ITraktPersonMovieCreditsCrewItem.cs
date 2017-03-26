namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Movies;

    public interface ITraktPersonMovieCreditsCrewItem
    {
        string Job { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
