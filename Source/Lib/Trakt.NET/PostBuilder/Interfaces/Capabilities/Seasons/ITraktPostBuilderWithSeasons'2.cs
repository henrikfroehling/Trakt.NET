namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Seasons;

    public interface ITraktPostBuilderWithSeasons<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);
    }
}
