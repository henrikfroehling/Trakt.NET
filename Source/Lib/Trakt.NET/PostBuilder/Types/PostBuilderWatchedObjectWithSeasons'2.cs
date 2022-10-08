namespace TraktNet.PostBuilder
{
    internal sealed class PostBuilderWatchedObjectWithSeasons<TObject, TSeasons> : PostBuilderWatchedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
