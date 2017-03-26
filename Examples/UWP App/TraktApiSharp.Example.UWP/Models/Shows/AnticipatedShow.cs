namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    public class AnticipatedShow : TraktShow
    {
        public int? ListCount { get; set; }
    }
}
