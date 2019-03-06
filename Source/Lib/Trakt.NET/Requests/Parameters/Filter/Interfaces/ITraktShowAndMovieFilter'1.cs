namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    public interface ITraktShowAndMovieFilter<T> : ITraktFilter<ITraktShowAndMovieFilter<T>> where T : ITraktShowAndMovieFilter<T>
    {
        string[] Certifications { get; }

        T AddCertifications(string certification, params string[] certifications);

        T WithCertifications(string certificatio, params string[] certifications);

        T ClearCertifications();
    }
}
