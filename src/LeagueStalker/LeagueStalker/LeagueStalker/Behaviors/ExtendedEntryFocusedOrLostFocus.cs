using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeagueStalker.Behaviors
{
    public class ExtendedEntryFocusedOrLostFocus : Behavior<Entry>
    {
        public static readonly BindableProperty isFocusedProperty = BindableProperty.Create("Focused", typeof(bool), typeof(ExtendedEntryFocusedOrLostFocus), false);
        public static readonly BindableProperty lostFocusProperty = BindableProperty.Create("LostFocus", typeof(bool), typeof(ExtendedEntryFocusedOrLostFocus), true);

        public bool Focused
        {
            get { return (bool)GetValue(isFocusedProperty); }
            set { SetValue(isFocusedProperty, value); }
        }
        public bool LostFocus
        {
            get { return (bool)GetValue(lostFocusProperty); }
            set { SetValue(lostFocusProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Focused += Bindable_Focused;
            bindable.Unfocused += Bindable_Unfocused;
        }

        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            if (!e.IsFocused)
                ((CustomControls.ExtendedEntry)sender).BorderColor = (Color)Application.Current.Resources["DisabledColor"];
        }

        private void Bindable_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
                ((CustomControls.ExtendedEntry)sender).BorderColor = (Color)Application.Current.Resources["ThemeColor"];
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Focused -= Bindable_Focused;
            bindable.Unfocused -= Bindable_Unfocused;
        }
    }
}
