namespace TraktNet.Parameters
{
    public interface ITraktShowAndMovieFilter : ITraktFilter
    {
        /// <summary>Optional US content certifications.</summary>
        string[] Certifications { get; set; }
    }
}
