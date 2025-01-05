namespace ShopConnect.ViewModels.Shell
{
    public class PhotoCarouselViewModel
    {
        public ObservableCollection<string> Photos { get; set; }

        public PhotoCarouselViewModel()
        {
            Photos = new ObservableCollection<string>
            {
                "https://vegayazilim.com.tr/wp-content/uploads/2024/02/vega_sadakat_bosYY.jpg",
                "https://vegayazilim.com.tr/wp-content/uploads/2024/01/vepos-.jpg",
                "https://vegayazilim.com.tr/wp-content/uploads/2024/01/e-donusum1.jpg",
                "https://vegayazilim.com.tr/wp-content/uploads/2023/12/armada-1.jpg",
            };
        }
    }
}
