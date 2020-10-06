namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    public interface ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithSeasons(TSeasonCollection seasons);
    }
}
