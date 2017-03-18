namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Movies;

    public interface ITraktPersonMovieCreditsCastItem
    {
        string Character { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
