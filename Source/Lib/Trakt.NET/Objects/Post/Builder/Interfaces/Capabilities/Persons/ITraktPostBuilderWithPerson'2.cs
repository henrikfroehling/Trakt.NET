namespace TraktNet.Objects.Post.Capabilities
{
    using Get.People;

    public interface ITraktPostBuilderWithPerson<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithPerson(ITraktPerson person);
    }
}
