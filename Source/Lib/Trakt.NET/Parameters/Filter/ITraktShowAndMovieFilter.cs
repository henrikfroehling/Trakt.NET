namespace TraktNet.Parameters
{
    public interface ITraktShowAndMovieFilter : ITraktFilter
    {
        string[] Certifications { get; set; }
    }
}
