using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using LeagueStalker.CustomControls;
using Xamarin.Forms;
using LeagueStalker.iOS.CustomRenderers;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace LeagueStalker.iOS.CustomRenderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;
            if ((Control != null) && (e.NewElement != null))
                Control.ReturnKeyType = (e.NewElement as ExtendedEntry).ReturnKeyType.GetValueFromDescription();

            Control.BorderStyle = UITextBorderStyle.None;
            UpdateBorderWidth();
            UpdateBorderColor();
            UpdateBorderRadius();
            UpdateLeftPadding();
            UpdateRightPadding();
            UpdateShowDoneToolBarInKeyboard();
            Control.ClipsToBounds = true;

            //Turn off auto capitalization
            Control.AutocapitalizationType = UITextAutocapitalizationType.None;

            //Turn off autocorrection
            Control.AutocorrectionType = UITextAutocorrectionType.No;

            //Turn off autospelling 
            Control.SpellCheckingType = UITextSpellCheckingType.No;

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            if (e.PropertyName == ExtendedEntry.BorderWidthProperty.PropertyName)
            {
                UpdateBorderWidth();
            }
            else if (e.PropertyName == ExtendedEntry.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor();
            }
            else if (e.PropertyName == ExtendedEntry.BorderRadiusProperty.PropertyName)
            {
                UpdateBorderRadius();
            }
            else if (e.PropertyName == ExtendedEntry.LeftPaddingProperty.PropertyName)
            {
                UpdateLeftPadding();
            }
            else if (e.PropertyName == ExtendedEntry.RightPaddingProperty.PropertyName)
            {
                UpdateRightPadding();
            }
            else if (e.PropertyName == ExtendedEntry.ReturnKeyTypeProperty.PropertyName)
            {
                //D.WriteLine($"{(sender as ExtendedEntry).ReturnKeyType.ToString()}");
                Control.ReturnKeyType = (sender as ExtendedEntry).ReturnKeyType.GetValueFromDescription();
            }
            else if(e.PropertyName == ExtendedEntry.EnableDoneToolBarProperty.PropertyName)
            {
                UpdateShowDoneToolBarInKeyboard();
            }
        }

        #region Utility methods

        private void UpdateBorderWidth()
        {
            var exEntry = this.Element as ExtendedEntry;
            Control.Layer.BorderWidth = exEntry.BorderWidth;
        }

        private void UpdateBorderColor()
        {
            var exEntry = this.Element as ExtendedEntry;
            Control.Layer.BorderColor = exEntry.BorderColor.ToUIColor().CGColor;
        }

        private void UpdateBorderRadius()
        {
            var exEntry = this.Element as ExtendedEntry;
            Control.Layer.CornerRadius = (nfloat)exEntry.BorderRadius;
        }

        private void UpdateLeftPadding()
        {
            var exEntry = this.Element as ExtendedEntry;
            var leftPaddingView = new UIView(new CGRect(0, 0, exEntry.LeftPadding, 0));
            Control.LeftView = leftPaddingView;
            Control.LeftViewMode = UITextFieldViewMode.Always;
        }

        private void UpdateRightPadding()
        {
            var exEntry = this.Element as ExtendedEntry;
            var rightPaddingView = new UIView(new CGRect(0, 0, exEntry.RightPadding, 0));
            Control.RightView = rightPaddingView;
            Control.RightViewMode = UITextFieldViewMode.Always;
        }

        private void UpdateShowDoneToolBarInKeyboard()
        {
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
            };
            
            this.Control.InputAccessoryView = toolbar;
        }

        #endregion
    }

    public static class EnumExtensions
    {
        public static UIReturnKeyType GetValueFromDescription(this ReturnKeyTypes value)
        {
            var type = typeof(UIReturnKeyType);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value.ToString())
                        return (UIReturnKeyType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value.ToString())
                        return (UIReturnKeyType)field.GetValue(null);
                }
            }
            throw new NotSupportedException($"Not supported on iOS: {value}");
        }
    }
}