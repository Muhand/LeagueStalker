using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.Views.Signup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ValidatingSummonerName : ContentPage
	{
		public ValidatingSummonerName (string summonerName)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Signup.ValidatingSummonerNameViewModel(summonerName);
		}
	}
}