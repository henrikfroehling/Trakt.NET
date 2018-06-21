namespace TraktNet.Objects.Basic
{
    using Get.People;

    public interface ITraktCastMember
    {
        string Character { get; set; }

        ITraktPerson Person { get; set; }
    }
}
