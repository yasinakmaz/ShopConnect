using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopConnect.Service
{
    public class CustomSearchHandler : SearchHandler
    {
        private readonly DatabaseService databaseService;

        public CustomSearchHandler()
        {
            databaseService = new DatabaseService();

            // Öğe şablonu ekle
            ItemTemplate = new DataTemplate(() =>
            {
                var label = new Label
                {
                    Margin = new Thickness(10),
                    FontSize = 16
                };
                label.SetBinding(Label.TextProperty, ".");

                return new Grid
                {
                    Children = { label }
                };
            });
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

            if (item is string selectedItem)
            {
                Application.Current.MainPage.DisplayAlert("Seçilen Öğe", selectedItem, "Tamam");
            }
        }
    }

}
