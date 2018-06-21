namespace TraktNet.Objects.Basic
{
    using Get.People;

    public interface ITraktCrewMember
    {
        string Job { get; set; }

        ITraktPerson Person { get; set; }
    }
}
