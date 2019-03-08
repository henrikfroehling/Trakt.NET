namespace TraktNet.Requests.Parameters.Filter
{
    public abstract class TraktShowAndMovieFilter<T> : TraktFilter<TraktShowAndMovieFilter<T>> where T : TraktShowAndMovieFilter<T>
    {
        public string[] Certifications { get; protected set; }

        public T AddCertifications(string certification, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        public T WithCertifications(string certificatio, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        public T ClearCertifications()
        {
            throw new System.NotImplementedException();
        }
    }
}
