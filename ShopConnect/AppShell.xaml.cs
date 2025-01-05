namespace ShopConnect
{
    public partial class AppShell : Shell
    {
        private bool _isRunning = true;
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new PhotoCarouselViewModel();
            StartAutoSlide();
        }

        private async void StartAutoSlide()
        {
            while (_isRunning)
            {
                await Task.Delay(3000);

                if (PhotoCarousel.ItemsSource is Array items && items.Length > 0)
                {
                    PhotoCarousel.Position += 1;
                }
            }
        }
    }
}
