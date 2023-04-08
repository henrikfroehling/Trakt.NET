namespace TraktNet.Requests.Interfaces
{
    public interface IValidatable
    {
        /// <summary>Checks whether the post data is valid.</summary>
        void Validate();
    }
}
