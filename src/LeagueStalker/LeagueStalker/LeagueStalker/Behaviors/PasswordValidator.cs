using LeagueStalker.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LeagueStalker.Behaviors
{
    public class PasswordValidator : Behavior<ExtendedEntry>
    {
        public static readonly BindableProperty MinLengthPropertyKey = BindableProperty.Create(
            propertyName: "MinLength",
            returnType: typeof(int),
            declaringType: typeof(PasswordValidator),
            defaultValue: 0);

        public int MinLength
        {
            get { return (int)GetValue(MinLengthPropertyKey); }
            set { SetValue(MinLengthPropertyKey, value); }
        }

        public static readonly BindableProperty RestrictionsPropertyKey = BindableProperty.Create(
            propertyName: "Restrictions",
            returnType: typeof(PasswordRestrictions),
            declaringType: typeof(PasswordValidator),
            defaultValue: PasswordRestrictions.NoRestrictions);

        public PasswordRestrictions Restrictions
        {
            get { return (PasswordRestrictions)GetValue(RestrictionsPropertyKey); }
            set { SetValue(RestrictionsPropertyKey, value); }
        }

        public static readonly BindableProperty IsValidPropertyKey = BindableProperty.Create(
            propertyName: "IsValid",
            returnType: typeof(bool),
            declaringType: typeof(PasswordValidator),
            defaultValue: false);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidPropertyKey); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(ExtendedEntry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExtendedEntry temp = (ExtendedEntry)sender;
            var chars = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', '{', '}', '[', ']', '\\', '|', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?' };
            var nums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            switch (Restrictions)
            {
                case PasswordRestrictions.NoRestrictions:
                    if (temp.Text.Length >= MinLength)
                        IsValid = true;
                    else
                        IsValid = false;
                    break;
                case PasswordRestrictions.IncludeChars:
                    if ((temp.Text.Length >= MinLength) && temp.Text.IndexOfAny(chars) != -1)
                        IsValid = true;
                    else
                        IsValid = false;
                    break;
                case PasswordRestrictions.IncludeNumbers:
                    if ((temp.Text.Length >= MinLength) && temp.Text.IndexOfAny(nums) != -1)
                        IsValid = true;
                    else
                        IsValid = false;
                    break;
                case PasswordRestrictions.IncludeCaps:
                    if ((temp.Text.Length >= MinLength) && temp.Text.Any(c => char.IsUpper(c)))
                        IsValid = true;
                    else
                        IsValid = false;
                    break;
                case PasswordRestrictions.IncludeAll:
                    if ((temp.Text.Length >= MinLength) && temp.Text.Any(c => char.IsUpper(c)) &&
                        temp.Text.IndexOfAny(nums) != -1 && temp.Text.IndexOfAny(chars) != -1)
                        IsValid = true;
                    else
                        IsValid = false;
                        break;
                default:
                    IsValid = false;
                    throw new Exception("Unknown restriction");
            }

            if (!IsValid)
                temp.BorderColor = (Color)Application.Current.Resources["NotValidEntry"];
            else
                temp.BorderColor = (Color)Application.Current.Resources["ThemeColor"];
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
        }
    }

    public enum PasswordRestrictions : int
    {
        NoRestrictions,
        IncludeChars,
        IncludeNumbers,
        IncludeCaps,
        IncludeAll
    }

}
