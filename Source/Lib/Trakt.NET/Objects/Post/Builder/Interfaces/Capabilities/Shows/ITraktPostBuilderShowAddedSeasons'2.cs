namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    public interface ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddShow WithSeasons(int[] seasons);

        TPostBuilderAddShow WithSeasons(int season, params int[] seasons);
    }
}
