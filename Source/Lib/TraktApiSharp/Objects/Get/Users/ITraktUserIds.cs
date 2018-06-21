namespace TraktNet.Objects.Get.Users
{
    using Basic;

    public interface ITraktUserIds : IIds
    {
        string Slug { get; set; }
    }
}
