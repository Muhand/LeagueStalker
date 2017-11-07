using LeagueStalker.CustomControls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeagueStalker.Behaviors
{
    class SummonerNameValidator : Behavior<ExtendedEntry>
    {
        private bool TextChanged { get; set; }

        protected override void OnAttachedTo(ExtendedEntry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            bindable.Unfocused += Bindable_Unfocused;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged = true;
        }

        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            if (TextChanged == true && ((ExtendedEntry)sender).Text != "")
            {
                TextChanged = false;

                Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.ValidatingSummonerName(((ExtendedEntry)sender).Text));
            }
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
            bindable.Unfocused -= Bindable_Unfocused;
        }
    }
}
