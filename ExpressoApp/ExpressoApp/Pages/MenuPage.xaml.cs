using ExpressoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressoApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        public ObservableCollection<ExpressoApp.Models.Menu> Menus;
        public static bool first = true;
		public MenuPage ()
		{
			InitializeComponent ();
            Menus = new ObservableCollection<ExpressoApp.Models.Menu>();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (first)
            {
                var apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                    Console.WriteLine(menu.Name);
                }
                LvMenu.ItemsSource = Menus;
                BusyIndicator.IsRunning = false;

            }
            first = false;
        }
        private void LvMenu_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu = e.SelectedItem as Models.Menu;
            if (selectedMenu != null)
            {
                Navigation.PushAsync(new SubMenuPage(selectedMenu));
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}