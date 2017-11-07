
using Xamarin.Forms;

namespace LeagueStalker.ViewModels.Dashboard
{
    class MainViewModel
    {
        #region Constructor(s)
        public MainViewModel(TabbedPage tabbedPage)
        {
            var pages = tabbedPage.Children.GetEnumerator();
            pages.MoveNext();   //Move to the 1st page
            pages.MoveNext();   //Move to the 2nd page
            
            //Set the current page to be the 2nd page
            tabbedPage.CurrentPage = pages.Current;
        }
        #endregion
    }
}
