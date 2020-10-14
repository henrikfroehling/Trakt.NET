namespace TraktNet.Objects.Post.Builder
{
    public sealed class PostBuilderWatchedObjectWithSeasons<TObject, TSeasons> : PostBuilderWatchedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
