namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Services.TraktService;

    public class MainPageViewModel : BaseViewModel
    {
        public bool IsTraktClientIdAvailable => TraktServiceProvider.Instance.Client.IsValidForUseWithoutAuthorization;
    }
}
