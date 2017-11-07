using Xamarin.Forms;

namespace LeagueStalker.CustomControls
{
    public class ExtendedEntry : Entry
    {

        public ExtendedEntry() :base() { }

        public static readonly BindableProperty ReturnKeyTypeProperty = BindableProperty.Create(
            propertyName: "ReturnKeyType",
            returnType: typeof(ReturnKeyTypes),
            declaringType: typeof(ExtendedEntry),
            defaultValue: ReturnKeyTypes.Done);

        public ReturnKeyTypes ReturnKeyType
        {
            get { return (ReturnKeyTypes)GetValue(ReturnKeyTypeProperty); }
            set { SetValue(ReturnKeyTypeProperty, value); }
        }

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            propertyName: "BorderRadius",
            returnType: typeof(double),
            declaringType: typeof(ExtendedEntry),
            defaultValue: 0.0);

        public double BorderRadius
        {
            get { return (double)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            propertyName: "BorderWidth",
            returnType: typeof(float),
            declaringType: typeof(ExtendedEntry),
            defaultValue: 0.0f);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: "BorderColor",
            returnType: typeof(Color),
            declaringType: typeof(ExtendedEntry),
            defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty LeftPaddingProperty = BindableProperty.Create(
            propertyName: "LeftPadding",
            returnType: typeof(double),
            declaringType: typeof(ExtendedEntry),
            defaultValue: 0.0);

        public double LeftPadding
        {
            get { return (double)GetValue(LeftPaddingProperty); }
            set { SetValue(LeftPaddingProperty, value); }
        }

        public static readonly BindableProperty RightPaddingProperty = BindableProperty.Create(
            propertyName: "RightPadding",
            returnType: typeof(double),
            declaringType: typeof(ExtendedEntry),
            defaultValue: 0.0);

        public double RightPadding
        {
            get { return (double)GetValue(RightPaddingProperty); }
            set { SetValue(RightPaddingProperty, value); }
        }

        public static readonly BindableProperty EnableDoneToolBarProperty = BindableProperty.Create(
            propertyName: "EnableDoneToolBar",
            returnType: typeof(bool),
            declaringType: typeof(ExtendedEntry),
            defaultValue: false);

        public bool EnableDoneToolBar
        {
            get { return (bool)GetValue(EnableDoneToolBarProperty); }
            set { SetValue(EnableDoneToolBarProperty, value); }
        }

        public static readonly BindableProperty AutoCapitalizeProperty = BindableProperty.Create(
            propertyName: "AutoCapitalize",
            returnType: typeof(AutoCapitalizationType),
            declaringType: typeof(ExtendedEntry),
            defaultValue: AutoCapitalizationType.Words);

        public AutoCapitalizationType AutoCapitalize
        {
            get { return (AutoCapitalizationType)GetValue(AutoCapitalizeProperty); }
            set { SetValue(AutoCapitalizeProperty, value); }
        }

        public static readonly BindableProperty AutoCorrectProperty = BindableProperty.Create(
            propertyName: "AutoCorrect",
            returnType: typeof(AutoCorrectionType),
            declaringType: typeof(ExtendedEntry),
            defaultValue: AutoCorrectionType.Default);

        public AutoCorrectionType AutoCorrect
        {
            get { return (AutoCorrectionType)GetValue(AutoCorrectProperty); }
            set { SetValue(AutoCorrectProperty, value); }
        }

        public static readonly BindableProperty SpellCheckingProperty = BindableProperty.Create(
            propertyName: "SpellChecking",
            returnType: typeof(AutoSpellCheckingType),
            declaringType: typeof(ExtendedEntry),
            defaultValue: AutoSpellCheckingType.Default);

        public AutoSpellCheckingType SpellChecking
        {
            get { return (AutoSpellCheckingType)GetValue(SpellCheckingProperty); }
            set { SetValue(SpellCheckingProperty, value); }
        }

        //public static readonly BindableProperty TopPaddingProperty = BindableProperty.Create(
        //    propertyName: "TopPadding",
        //    returnType: typeof(double),
        //    declaringType: typeof(ExtendedEntry),
        //    defaultValue: 0.0);

        //public double TopPadding
        //{
        //    get { return (double)GetValue(TopPaddingProperty); }
        //    set { SetValue(TopPaddingProperty, value); }
        //}

        //public static readonly BindableProperty BottomPaddingProperty = BindableProperty.Create(
        //    propertyName: "BottomPadding",
        //    returnType: typeof(double),
        //    declaringType: typeof(ExtendedEntry),
        //    defaultValue: 0.0);

        //public double BottomPadding
        //{
        //    get { return (double)GetValue(BottomPaddingProperty); }
        //    set { SetValue(BottomPaddingProperty, value); }
        //}
    }

    // Not all of these are support on Android, consult EntryEditText.ImeOptions
    public enum ReturnKeyTypes : int
    {
        Default,
        Go,
        Google,
        Join,
        Next,
        Route,
        Search,
        Send,
        Yahoo,
        Done,
        EmergencyCall,
        Continue
    }

    public enum AutoCapitalizationType : int
    {
        None,
        AllCharacters,
        Sentences,
        Words
    }
    public enum AutoCorrectionType : int
    {
        No,
        Yes,
        Default
    }
    public enum AutoSpellCheckingType : int
    {
        No,
        Yes,
        Default
    }

}
