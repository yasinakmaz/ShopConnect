using CommunityToolkit.Maui.Views;

namespace ShopConnect.Pages.Sale;

public partial class PopupTest : Popup
{
	public PopupTest()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
	    CloseAsync();
    }
}