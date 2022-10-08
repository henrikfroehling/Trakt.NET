namespace TraktNet.PostBuilder
{
    public interface ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithSeasons(int[] seasons);

        TPostBuilderAddShow WithSeasons(int season, params int[] seasons);
    }
}
