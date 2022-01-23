namespace TraktNet.Objects.Post
{
    internal sealed class PostBuilderCollectedObjectWithSeasons<TObject, TSeasons> : PostBuilderCollectedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
