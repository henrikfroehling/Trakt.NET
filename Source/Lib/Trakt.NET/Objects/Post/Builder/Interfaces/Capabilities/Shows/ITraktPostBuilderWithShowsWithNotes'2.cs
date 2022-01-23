namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithShowsWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsWithNotes(IEnumerable<Tuple<ITraktShow, string>> shows);
    }
}
