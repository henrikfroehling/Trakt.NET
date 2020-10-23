namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Seasons;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithSeasons<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);
    }
}
