namespace TraktNet.Objects.Post.Syncs.Lists
{
    using Enums;
    using Exceptions;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A Trakt list update post.</summary>
    public class TraktUpdateListPost : ITraktUpdateListPost
    {
        /// <summary>The description for the list.</summary>
        public string Description { get; set; }

        /// <summary>The sort by value for the list.</summary>
        public TraktSortBy SortBy { get; set; }

        /// <summary>The sort how value for the list.</summary>
        public TraktSortHow SortHow { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktUpdateListPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktUpdateListPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            bool hasNoDescription = string.IsNullOrEmpty(Description);
            bool hasNoSortBy = SortBy == null || SortBy == TraktSortBy.Unspecified;
            bool hasNoSortHow = SortHow == null || SortHow == TraktSortHow.Unspecified;

            if (hasNoDescription && hasNoSortBy && hasNoSortHow) {
                throw new TraktPostValidationException("no list update values set");
            }
        }
    }
}
