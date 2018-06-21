namespace TraktNet.Objects.Get.Users
{
    using Basic;

    public interface ITraktUserSettings
    {
        ITraktUser User { get; set; }

        ITraktAccountSettings Account { get; set; }

        ITraktSharing Connections { get; set; }

        ITraktSharingText SharingText { get; set; }
    }
}
