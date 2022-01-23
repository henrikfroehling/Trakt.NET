namespace TraktNet.Objects.Post
{
    internal sealed class PostBuilderRatedObjectWithSeasons<TObject, TSeasons> : PostBuilderRatedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
