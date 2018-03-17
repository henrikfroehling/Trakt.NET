namespace TraktApiSharp.Requests.Interfaces
{
    public interface IRequestBody : IValidatable
    {
        string ToJson();
    }
}
