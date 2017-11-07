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
	public partial class ProcessSignup : ContentPage
	{
		public ProcessSignup (string email, string summonerName, string password)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Signup.ProcessSignupViewModel(email,summonerName,password);
		}
	}
}