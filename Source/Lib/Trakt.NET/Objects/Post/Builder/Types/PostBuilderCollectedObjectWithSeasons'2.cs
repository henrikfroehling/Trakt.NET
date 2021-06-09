namespace TraktNet.Objects.Post
{
    public sealed class PostBuilderCollectedObjectWithSeasons<TObject, TSeasons> : PostBuilderCollectedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
