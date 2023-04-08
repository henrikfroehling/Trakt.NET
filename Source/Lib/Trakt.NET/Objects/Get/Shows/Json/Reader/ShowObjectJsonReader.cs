namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    internal class ShowObjectJsonReader : AShowObjectJsonReader<ITraktShow>
    {
        protected override ITraktShow CreateShowObject() => new TraktShow();
    }
}
