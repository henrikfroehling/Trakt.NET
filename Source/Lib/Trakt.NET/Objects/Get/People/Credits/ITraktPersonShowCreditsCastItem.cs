namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;

    public interface ITraktPersonShowCreditsCastItem
    {
        string Character { get; set; }

        ITraktShow Show { get; set; }
    }
}
