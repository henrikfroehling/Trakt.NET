namespace TraktNet.Objects.Basic
{
    public interface IIds
    {
        /// <summary>Returns, whether any id has been set.</summary>
        bool HasAnyId { get; }

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        string GetBestId();
    }
}
