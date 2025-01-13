global using Microsoft.Data.SqlClient;
using CommunityToolkit.Maui.Views;

namespace ShopConnect.Pages.Sale;

public partial class CashSalePage : ContentPage
{
    public CashSalePage()
    {
        InitializeComponent();
    }

    private void OnShowPopupClicked(object sender, EventArgs e)
    {
        var popup = new PopupTest();
        this.ShowPopup(popup);
    }
}
