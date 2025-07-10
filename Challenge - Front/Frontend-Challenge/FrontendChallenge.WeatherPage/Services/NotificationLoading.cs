namespace FrontendChallenge.WeatherPage.Services
{
    public class NotificationLoading : INotificationLoading, IDisposable
    {
        private bool _disposed;

        public event Action OnShow;
        public event Action OnClose;

        public NotificationLoading(){}

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    CloseModal();
                }
                _disposed = true;
            }
        }

        public void ShowModal()
        {
            try
            {
                if (OnShow is not null)
                {
                    OnShow?.Invoke();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void CloseModal()
        {
            OnClose?.Invoke();
        }
    }
}
