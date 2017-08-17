using Linoleum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Linoleum
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var linoleums = new List<LinoleumRoll>();
            for(int i = 0; i < 40; i++)
            {
                linoleums.Add(new LinoleumRoll { Id = i, Name = "linoleum " + i, Image = "Icon.png", LengthLeft = 100,
                Price = Byn.GetInstance((decimal)(10.15 + i)), ProtectionLayerWidth = 2.5F, TotalLength = 300, Width = 2.5F });
            }


            listView.ItemsSource = linoleums;

            listView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }


	}
}
