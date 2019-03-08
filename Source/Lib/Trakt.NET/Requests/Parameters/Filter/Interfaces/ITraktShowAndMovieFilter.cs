namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    public interface ITraktShowAndMovieFilter : ITraktFilter
    {
        string[] Certifications { get; }
    }
}
