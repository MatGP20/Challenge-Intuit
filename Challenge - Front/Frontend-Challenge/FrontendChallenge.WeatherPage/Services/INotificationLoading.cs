namespace FrontendChallenge.WeatherPage.Services
{
    public interface INotificationLoading
    {
        event Action OnShow;
        event Action OnClose;

        void ShowModal();
        void CloseModal();
    }
}
