using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProcessLogin : ContentPage
	{
		public ProcessLogin (string email, string password)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.ProcessLoginViewModel(email, password);
		}
	}
}