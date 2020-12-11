namespace TraktNet.Objects.Post
{
    public sealed class PostBuilderWatchedObjectWithSeasons<TObject, TSeasons> : PostBuilderWatchedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
