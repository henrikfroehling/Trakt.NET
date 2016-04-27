namespace TraktApiSharp.Modules
{
    using Objects.Basic;
    using Requests;
    using Requests.WithoutOAuth.Comments;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktCommentModule : TraktBaseModule
    {
        public TraktCommentModule(TraktClient client) : base(client) { }

        public async Task<TraktComment> GetCommentAsync(string id)
        {
            return await QueryAsync(new TraktCommentSummaryRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktListResult<TraktComment>> GetCommentsAsync(string[] ids)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var comments = new List<TraktComment>();

            foreach (var id in ids)
            {
                var show = await GetCommentAsync(id);

                if (show != null)
                    comments.Add(show);
            }

            return new TraktListResult<TraktComment> { Items = comments };
        }

        public async Task<TraktComment> GetCommentReplyAsync(string replyId)
        {
            return await QueryAsync(new TraktCommentReplySummaryRequest(Client)
            {
                Id = replyId
            });
        }

        public async Task<TraktPaginationListResult<TraktComment>> GetCommentRepliesAsync(string id, int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktCommentRepliesRequest(Client)
            {
                Id = id,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }
    }
}
