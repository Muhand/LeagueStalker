using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace LeagueStalker.CustomControls
{
    public class ExtendedImage : Image
    {
        public static readonly BindableProperty IsCircularProperty = BindableProperty.Create(
            propertyName: "IsCircular",
            returnType: typeof(bool),
            declaringType: typeof(ExtendedImage),
            defaultValue: false);

        public bool IsCircular
        {
            get { return (bool)GetValue(IsCircularProperty); }
            set { SetValue(IsCircularProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            propertyName: "BorderWidth",
            returnType: typeof(float),
            declaringType: typeof(ExtendedImage),
            defaultValue: 0.0f);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            propertyName: "CornerRadius",
            returnType: typeof(float),
            declaringType: typeof(ExtendedImage),
            defaultValue: 0.0f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: "BorderColor",
            returnType: typeof(Color),
            declaringType: typeof(ExtendedImage),
            defaultValue: (Color)Application.Current.Resources["DisabledColor"]);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
