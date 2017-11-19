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
	public partial class PerkView : ContentView
	{
        #region Properties
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
            propertyName: "ImageSource",
            returnType: typeof(string),
            declaringType: typeof(PerkView),
            defaultValue: "");

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty IsKeystoneProperty = BindableProperty.Create(
            propertyName: "IsKeystone",
            returnType: typeof(bool),
            declaringType: typeof(PerkView),
            defaultValue: false);

        public bool IsKeystone
        {
            get { return (bool)GetValue(IsKeystoneProperty); }
            set { SetValue(IsKeystoneProperty, value); }
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: "Title",
            returnType: typeof(string),
            declaringType: typeof(PerkView),
            defaultValue: "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(
            propertyName: "TitleColor",
            returnType: typeof(Color),
            declaringType: typeof(PerkView),
            defaultValue: Color.Default);

        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
            propertyName: "Description",
            returnType: typeof(string),
            declaringType: typeof(PerkView),
            defaultValue: "");

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        #endregion

        #region Constructor(s)
        public PerkView ()
		{
			InitializeComponent ();
            BindingContext = this;
        }
        #endregion
    }
}