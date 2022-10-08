namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderWithShowsWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsWithNotes(IEnumerable<Tuple<ITraktShow, string>> shows);
    }
}
