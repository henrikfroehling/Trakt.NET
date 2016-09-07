namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;

    public class BoxOfficeMovie : TraktMovie
    {
        public int? Revenue { get; set; }
    }
}
