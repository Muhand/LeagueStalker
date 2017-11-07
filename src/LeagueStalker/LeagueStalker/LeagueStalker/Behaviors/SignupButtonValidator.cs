using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeagueStalker.Behaviors
{
    class SignupButtonValidator : Behavior<Button>
    {
        public static readonly BindableProperty IsValidEmailPropertyKey = BindableProperty.Create(
           propertyName: "IsValidEmail",
           returnType: typeof(bool),
           declaringType: typeof(SignupButtonValidator),
           defaultValue: false);

        public bool IsValidEmail
        {
            get { return (bool)GetValue(IsValidEmailPropertyKey); }
            set { SetValue(IsValidEmailPropertyKey, value); }
        }

        public static readonly BindableProperty IsValidPasswordPropertyKey = BindableProperty.Create(
           propertyName: "IsValidPassword",
           returnType: typeof(bool),
           declaringType: typeof(SignupButtonValidator),
           defaultValue: false);

        public bool IsValidPassword
        {
            get { return (bool)GetValue(IsValidPasswordPropertyKey); }
            set { SetValue(IsValidPasswordPropertyKey, value); }
        }

        protected override void OnAttachedTo(Button bindable)
        {
            if (IsValidEmail && IsValidPassword)
                bindable.IsEnabled = true;
            else
                bindable.IsEnabled = false;
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
