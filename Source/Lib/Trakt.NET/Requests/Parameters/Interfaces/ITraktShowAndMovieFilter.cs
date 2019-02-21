namespace TraktNet.Requests.Parameters.Interfaces
{
    public interface ITraktShowAndMovieFilter : ITraktFilter
    {
        string[] Certifications { get; }

        ITraktShowAndMovieFilter AddCertifications(string certification, params string[] certifications);

        ITraktShowAndMovieFilter WithCertifications(string certificatio, params string[] certifications);

        ITraktShowAndMovieFilter ClearCertifications();
    }
}
