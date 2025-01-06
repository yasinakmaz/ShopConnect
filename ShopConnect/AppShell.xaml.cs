namespace ShopConnect
{
    public partial class AppShell : Shell
    {
        private bool _isRunning = true;
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new PhotoCarouselViewModel();
        }
    }
}
