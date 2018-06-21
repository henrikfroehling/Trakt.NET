namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class TraktUserHiddenItemsPost : ITraktUserHiddenItemsPost
    {
        public IEnumerable<ITraktUserHiddenItemsPostMovie> Movies { get; set; }

        public IEnumerable<ITraktUserHiddenItemsPostShow> Shows { get; set; }

        public IEnumerable<ITraktUserHiddenItemsPostSeason> Seasons { get; set; }

        public static TraktUserHiddenItemsPostBuilder Builder() => new TraktUserHiddenItemsPostBuilder();

        public HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUserHiddenItemsPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUserHiddenItemsPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // TODO
        }
    }
}
