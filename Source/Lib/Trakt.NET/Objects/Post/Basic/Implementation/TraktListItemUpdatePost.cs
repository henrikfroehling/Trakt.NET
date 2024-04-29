namespace TraktNet.Objects.Post.Basic
{
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class TraktListItemUpdatePost : ITraktListItemUpdatePost
    {
        public string Notes { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktListItemUpdatePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktListItemUpdatePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
        }
    }
}
