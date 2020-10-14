namespace TraktNet.Objects.Post.Builder
{
    internal sealed class PostBuilderRatedObjectWithSeasons<TObject, TSeasons> : PostBuilderRatedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
