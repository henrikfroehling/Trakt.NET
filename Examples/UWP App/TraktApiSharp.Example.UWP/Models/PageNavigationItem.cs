namespace TraktApiSharp.Example.UWP.Models
{
    using Template10.Mvvm;

    public class PageNavigationItem
    {
        public string Title { get; set; }

        public DelegateCommand GoTo { get; set; }
    }
}
