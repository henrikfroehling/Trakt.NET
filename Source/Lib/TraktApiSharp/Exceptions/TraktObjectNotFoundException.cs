namespace TraktApiSharp.Exceptions
{
    public abstract class TraktObjectNotFoundException : TraktException
    {
        public TraktObjectNotFoundException(string message, string objectId) : base(message)
        {
            ObjectId = objectId;
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        public string ObjectId { get; set; }
    }
}
