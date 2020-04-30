using LeagueStalker.ServerResponse.LOLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.Views.Dashboard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProcessMatchPreview : ContentPage
	{
		public ProcessMatchPreview (Match match)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.Dashboard.ProcessMatchPreviewViewModel(match);
		}
	}
}