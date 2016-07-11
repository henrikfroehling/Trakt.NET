namespace TraktApiSharp.Example.UWP.Models
{
    using Objects.Get.Movies;

    public class BoxOfficeMovie : TraktMovie
    {
        public int? Revenue { get; set; }
    }
}
