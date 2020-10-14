namespace TraktNet.Objects.Post.Builder
{
    public sealed class PostBuilderRatedObjectWithSeasons<TObject, TSeasons> : PostBuilderRatedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
