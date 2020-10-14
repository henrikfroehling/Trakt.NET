namespace TraktNet.Objects.Post.Builder
{
    internal sealed class PostBuilderWatchedObjectWithSeasons<TObject, TSeasons> : PostBuilderWatchedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
