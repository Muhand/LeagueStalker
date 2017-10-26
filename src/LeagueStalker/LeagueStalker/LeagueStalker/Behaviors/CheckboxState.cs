using LeagueStalker.CustomControls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeagueStalker.Behaviors
{

    public class CheckboxState : Behavior<Checkbox>
    {
        private TapGestureRecognizer tapGestureRecognizer { get; set; }

        public CheckboxState()
        {
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.NumberOfTapsRequired = 1;
        }

        protected override void OnAttachedTo(Checkbox bindable)
        {
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            bindable.GestureRecognizers.Add(tapGestureRecognizer); 
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var temp = (Checkbox)sender;
            temp.IsChecked = !temp.IsChecked;
        }

        protected override void OnDetachingFrom(Checkbox bindable)
        {
            tapGestureRecognizer.Tapped -= TapGestureRecognizer_Tapped;
            bindable.GestureRecognizers.Remove(tapGestureRecognizer);
        }
    }
}
