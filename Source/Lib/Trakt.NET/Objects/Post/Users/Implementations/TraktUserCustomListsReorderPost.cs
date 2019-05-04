namespace TraktNet.Objects.Post.Users
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class TraktUserCustomListsReorderPost : ITraktUserCustomListsReorderPost
    {
        public IEnumerable<uint> Rank { get; set; }

        public async Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUserCustomListsReorderPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUserCustomListsReorderPost>();
            return await objectJsonWriter.WriteObjectAsync(this, cancellationToken).ConfigureAwait(false);
        }

        public void Validate()
        {
        }
    }
}
