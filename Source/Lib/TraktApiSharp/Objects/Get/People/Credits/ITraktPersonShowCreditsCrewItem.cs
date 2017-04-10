namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Shows;

    public interface ITraktPersonShowCreditsCrewItem
    {
        string Job { get; set; }

        ITraktShow Show { get; set; }
    }
}
