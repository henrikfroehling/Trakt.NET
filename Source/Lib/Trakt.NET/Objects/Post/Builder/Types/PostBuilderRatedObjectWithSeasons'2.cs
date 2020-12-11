namespace TraktNet.Objects.Post
{
    public sealed class PostBuilderRatedObjectWithSeasons<TObject, TSeasons> : PostBuilderRatedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
