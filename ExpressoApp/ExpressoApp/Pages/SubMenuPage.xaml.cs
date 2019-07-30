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
	public partial class SubMenuPage : ContentPage
	{
        public ObservableCollection<SubMenu> subMenus;

		public SubMenuPage (Models.Menu menu)
		{
			InitializeComponent ();
            subMenus = new ObservableCollection<SubMenu>();
            foreach (SubMenu subMenuItem in menu.SubMenus)
            {
                if(!subMenuItem.Price.Contains("USD"))
                    subMenuItem.Price = subMenuItem.Price + " USD";
                subMenus.Add(subMenuItem);
            }
            LvSubMenu.ItemsSource = subMenus;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        
    }
}