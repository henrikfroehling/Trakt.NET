namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder AddShowWithNotes(ITraktShow show, string notes);
    }
}
