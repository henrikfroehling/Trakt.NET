namespace TraktNet.Objects.Post.Builder
{
    public sealed class PostBuilderCollectedObjectWithSeasons<TObject, TSeasons> : PostBuilderCollectedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
