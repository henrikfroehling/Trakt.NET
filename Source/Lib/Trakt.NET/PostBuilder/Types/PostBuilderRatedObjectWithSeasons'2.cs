namespace TraktNet.PostBuilder
{
    internal sealed class PostBuilderRatedObjectWithSeasons<TObject, TSeasons> : PostBuilderRatedObject<TObject>
    {
        public TSeasons Seasons { get; set; }
    }
}
