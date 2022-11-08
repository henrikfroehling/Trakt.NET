namespace TraktNet.Objects.Post.Basic
{
    using Exceptions;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class TraktListItemsReorderPost : ITraktListItemsReorderPost
    {
        public IEnumerable<uint> Rank { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktListItemsReorderPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktListItemsReorderPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            if (Rank == null)
                throw new TraktPostValidationException(nameof(Rank), "rank must not be null");
        }
    }
}
