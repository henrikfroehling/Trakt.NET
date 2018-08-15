namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListCommentPostArrayJsonReader : AArrayJsonReader<ITraktListCommentPost>
    {
        public override async Task<IEnumerable<ITraktListCommentPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktListCommentPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listCommentPostReader = new ListCommentPostObjectJsonReader();
                var listCommentPosts = new List<ITraktListCommentPost>();
                ITraktListCommentPost listCommentPost = await listCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (listCommentPost != null)
                {
                    listCommentPosts.Add(listCommentPost);
                    listCommentPost = await listCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return listCommentPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktListCommentPost>));
        }
    }
}
