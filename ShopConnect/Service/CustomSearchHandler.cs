using ShopConnect.Models;

namespace ShopConnect.Service
{
    public class CustomSearchHandler : SearchHandler
    {
        private readonly DatabaseService databaseService;

        public CustomSearchHandler()
        {
            databaseService = new DatabaseService();
        }

        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (!string.IsNullOrEmpty(newValue))
            {
                ItemsSource = await databaseService.SearchItemsAsync(newValue);
            }
            else
            {
                ItemsSource = null;
            }
        }

        protected override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            if (item is Cari selectedCari)
            {
                Application.Current.MainPage.DisplayAlert("Seçilen Cari", $"Firma: {selectedCari.FirmaAdi}\nYetkili: {selectedCari.Yetkili}", "Tamam");
            }
        }
    }

}
