namespace TraktApiSharp.Example.UWP.Models
{
    using Objects.Get.Movies;

    public class AnticipatedMovie : TraktMovie
    {
        public int? ListCount { get; set; }
    }
}
