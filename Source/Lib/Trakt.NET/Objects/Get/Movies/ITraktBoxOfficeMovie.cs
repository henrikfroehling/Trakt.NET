namespace TraktNet.Objects.Get.Movies
{
    public interface ITraktBoxOfficeMovie : ITraktMovie
    {
        int? Revenue { get; set; }

        ITraktMovie Movie { get; set; }
    }
}
