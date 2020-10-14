namespace TraktNet.Objects.Post.Builder
{
    internal sealed class PostBuilderCollectedObjectWithSeasons<TObject, TSeasons> : PostBuilderCollectedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
