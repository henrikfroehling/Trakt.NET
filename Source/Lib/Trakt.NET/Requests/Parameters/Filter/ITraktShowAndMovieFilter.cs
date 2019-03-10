namespace TraktNet.Requests.Parameters.Filter
{
    public interface ITraktShowAndMovieFilter : ITraktFilter
    {
        string[] Certifications { get; }
    }
}
