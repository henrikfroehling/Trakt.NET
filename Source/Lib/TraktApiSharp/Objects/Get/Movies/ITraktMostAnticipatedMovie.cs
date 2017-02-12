namespace TraktApiSharp.Objects.Get.Movies
{
    public interface ITraktMostAnticipatedMovie : ITraktMovie
    {
        int? ListCount { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
