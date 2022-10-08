namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.People;

    public interface ITraktPostBuilderWithPerson<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithPerson(ITraktPerson person);
    }
}
