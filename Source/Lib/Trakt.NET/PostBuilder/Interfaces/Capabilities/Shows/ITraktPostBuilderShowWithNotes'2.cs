namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder WithShowWithNotes(ITraktShow show, string notes);
    }
}
