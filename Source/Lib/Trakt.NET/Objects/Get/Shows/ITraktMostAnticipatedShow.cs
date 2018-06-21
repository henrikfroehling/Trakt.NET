namespace TraktNet.Objects.Get.Shows
{
    public interface ITraktMostAnticipatedShow : ITraktShow
    {
        int? ListCount { get; set; }

        ITraktShow Show { get; set; }
    }
}
