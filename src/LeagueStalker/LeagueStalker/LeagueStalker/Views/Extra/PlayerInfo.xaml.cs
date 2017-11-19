using LeagueStalker.ViewModels.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueStalker.ServerResponse.LOLAPI;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.Views.Extra
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerInfo : ContentPage
	{
		public PlayerInfo (Participant participant)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Extra.PlayerInfoViewModel(participant, MainRunesStackLayout,SubRunesStackLayout);
		}
	}
}