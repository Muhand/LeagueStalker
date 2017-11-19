using LeagueStalker.ServerResponse.LOLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.Views.Extra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Match : ContentPage
	{
		public Match (Game game, INavigation nav)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Extra.MatchViewModel(game, TeamA,TeamB, nav);
		}
	}
}