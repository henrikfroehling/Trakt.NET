namespace TraktNet.Objects.Post
{
    internal sealed class PostBuilderWatchedObjectWithSeasons<TObject, TSeasons> : PostBuilderWatchedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
