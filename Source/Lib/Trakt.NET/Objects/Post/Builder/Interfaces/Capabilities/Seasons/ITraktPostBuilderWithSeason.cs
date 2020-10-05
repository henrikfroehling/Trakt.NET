namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Seasons;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithSeason<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithSeason(ITraktSeason season);

        TPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);
    }
}
