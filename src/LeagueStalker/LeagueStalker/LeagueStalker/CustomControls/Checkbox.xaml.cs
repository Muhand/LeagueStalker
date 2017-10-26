using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Checkbox : ContentView
	{
		public Checkbox ()
		{
			InitializeComponent ();
		}

        #region Events
        public event EventHandler StateChanged;
        #endregion

        #region Checkbox Button
        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            propertyName: "BorderRadius",
            returnType: typeof(int),
            declaringType: typeof(Checkbox),
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: borderRadiusPropertyChanged);

        private static void borderRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxButton.BorderRadius = (int)newValue;
        }

        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            propertyName: "BorderWidth",
            returnType: typeof(float),
            declaringType: typeof(Checkbox),
            defaultValue: 1.0f,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: borderWidthPropertyChanged);

        private static void borderWidthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxButton.BorderWidth = (float)newValue;
        }

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: "BorderColor",
            returnType: typeof(Color),
            declaringType: typeof(Checkbox),
            defaultValue: Color.LightGray,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: borderColorPropertyChanged);

        private static void borderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxButton.BorderColor = (Color)newValue;
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            propertyName: "BackgroundColor",
            returnType: typeof(Color),
            declaringType: typeof(Checkbox),
            defaultValue: Color.White,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: backgroundColorPropertyChanged);

        private static void backgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxButton.BackgroundColor = (Color)newValue;
        }

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: "Height",
            returnType: typeof(double),
            declaringType: typeof(Checkbox),
            defaultValue: 24.0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: heightPropertyChanged);

        private static void heightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.HeightRequest = (double)newValue;
        }

        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: "Width",
            returnType: typeof(double),
            declaringType: typeof(Checkbox),
            defaultValue: 24.0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: widthPropertyChanged);

        private static void widthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxButton.WidthRequest = (double)newValue;
        }

        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }
        #endregion

        #region Checkbox Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(Checkbox),
            defaultValue: "Checkbox",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: textPropertyChanged);

        private static void textPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.Text = newValue.ToString();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: "FontSize",
            returnType: typeof(double),
            declaringType: typeof(Checkbox),
            defaultValue: 16.0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: fontSizePropertyChanged);

        private static void fontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.FontSize = (double)newValue;
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: "FontFamily",
            returnType: typeof(string),
            declaringType: typeof(Checkbox),
            defaultValue: "Segoe UI",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: fontFamilyPropertyChanged);

        private static void fontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.FontFamily = newValue.ToString();
        }

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: "TextColor",
            returnType: typeof(Color),
            declaringType: typeof(Checkbox),
            defaultValue: Color.White,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: textColorPropertyChanged);

        private static void textColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.TextColor = (Color)newValue;
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(
            propertyName: "HorizontalTextAlignment",
            returnType: typeof(TextAlignment),
            declaringType: typeof(Checkbox),
            defaultValue: TextAlignment.Start,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: horizontalTextAlignmentPropertyChanged);

        private static void horizontalTextAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.HorizontalTextAlignment = (TextAlignment)newValue;
        }

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(
            propertyName: "VerticalTextAlignment",
            returnType: typeof(TextAlignment),
            declaringType: typeof(Checkbox),
            defaultValue: TextAlignment.Center,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: verticalTextAlignmentPropertyChanged);

        private static void verticalTextAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxText.VerticalTextAlignment = (TextAlignment)newValue;
        }

        public TextAlignment VerticalTextAlignment
        {
            get { return (TextAlignment)GetValue(VerticalTextAlignmentProperty); }
            set { SetValue(VerticalTextAlignmentProperty, value); }
        }

        #endregion

        #region Checkbox Image
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
            propertyName: "IsChecked",
            returnType: typeof(bool),
            declaringType: typeof(Checkbox),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: isCheckedPropertyChanged);

        private static void isCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Checkbox)bindable;
            control.checkBoxImage.IsVisible = (bool)newValue;
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set
            {
                SetValue(IsCheckedProperty, value);
                RaiseAnEvent(StateChanged, EventArgs.Empty);
            }
        }
        #endregion

        #region Raising an event
        /// <summary>
        /// Raise an event
        /// </summary>
        /// <param name="eventHandler">The event you would like to raise</param>
        /// <param name="args">The event arguments</param>
        private void RaiseAnEvent(EventHandler eventHandler, EventArgs args)
        {
            //If event is not null then raise it
            eventHandler?.Invoke(this, args);
        }
        #endregion

        private void checkBoxButton_Clicked(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}