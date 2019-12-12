using viewwerXF.ApiServices;
using viewwerXF.ViewModels;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace viewwerXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabsPage : Xamarin.Forms.TabbedPage
    {
        WebApiService api = new WebApiService();
        public TabsPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            InitializeComponent();

            BindingContext = new TourViewModel(api);
        }
    }
}