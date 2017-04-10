namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    public class AnticipatedMovie : TraktMovie
    {
        public int? ListCount { get; set; }
    }
}
