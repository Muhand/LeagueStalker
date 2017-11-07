using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LeagueStalker.CustomControls;
using LeagueStalker.Droid.CustomRenderers;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Views.InputMethods;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace LeagueStalker.Droid.CustomRenderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        #region Private fields and properties

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            if ((Control != null) && (e.NewElement != null))
            {
                var entryExt = (e.NewElement as ExtendedEntry);
                Control.ImeOptions = entryExt.ReturnKeyType.GetValueFromDescription();
                // This is hackie ;-) / A Android-only bindable property should be added to the EntryExt class 
                Control.SetImeActionLabel(entryExt.ReturnKeyType.ToString(), Control.ImeOptions);
            }

            Control.Gravity = DefaultGravity;
            var entryEx = Element as ExtendedEntry;
            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);
            

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null)
                return;
            var exEntry = Element as ExtendedEntry;
            if (e.PropertyName == ExtendedEntry.BorderWidthProperty.PropertyName ||
                e.PropertyName == ExtendedEntry.BorderColorProperty.PropertyName ||
                e.PropertyName == ExtendedEntry.BorderRadiusProperty.PropertyName ||
                e.PropertyName == ExtendedEntry.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(exEntry);
            }
            else if (e.PropertyName == ExtendedEntry.LeftPaddingProperty.PropertyName ||
                e.PropertyName == ExtendedEntry.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(exEntry);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(exEntry);
            }
            else if (e.PropertyName == ExtendedEntry.ReturnKeyTypeProperty.PropertyName)
            {
                var entryExt = (sender as ExtendedEntry);
                Control.ImeOptions = entryExt.ReturnKeyType.GetValueFromDescription();
                // This is hackie ;-) / A Android-only bindable property should be added to the EntryExt class 
                Control.SetImeActionLabel(entryExt.ReturnKeyType.ToString(), Control.ImeOptions);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_renderer != null)
                {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }

        #endregion

        #region Utility methods

        private void UpdateBackground(ExtendedEntry exEntry)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            //Android.Graphics.Color adColor = exEntry.BorderColor.ToAndroid();
            
            Control.Background = _renderer.GetBorderBackground(exEntry.BorderColor, exEntry.BackgroundColor, exEntry.BorderWidth, (float)exEntry.BorderRadius);
        }

        private void UpdatePadding(ExtendedEntry exEntry)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(exEntry.LeftPadding), 0,
                (int)Forms.Context.ToPixels(exEntry.RightPadding), 0);
        }

        private void UpdateTextAlighnment(ExtendedEntry exEntry)
        {
            var gravity = DefaultGravity;
            switch (exEntry.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }

        #endregion
    }

    public static class EnumExtensions
    {
        public static ImeAction GetValueFromDescription(this ReturnKeyTypes value)
        {
            var type = typeof(ImeAction);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value.ToString())
                        return (ImeAction)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value.ToString())
                        return (ImeAction)field.GetValue(null);
                }
            }
            throw new NotSupportedException($"Not supported on Android: {value}");
        }
    }
}