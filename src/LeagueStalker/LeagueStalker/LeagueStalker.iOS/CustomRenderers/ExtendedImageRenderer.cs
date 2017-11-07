using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using LeagueStalker.CustomControls;
using LeagueStalker.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ExtendedImage), typeof(ExtendedImageRenderer))]
namespace LeagueStalker.iOS.CustomRenderers
{
    class ExtendedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element != null)
                return;

            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName || e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            try
            {
                var temp = this.Element as ExtendedImage;

                if (temp.IsCircular)
                {
                    double min = Math.Min(Element.Width, Element.Height);
                    Control.Layer.CornerRadius = (float)(min / 2.0);
                }
                else
                    Control.Layer.CornerRadius = temp.CornerRadius;

                Control.Layer.MasksToBounds = false;
                //Control.Layer.BorderColor = Color.White.ToCGColor();
                Control.Layer.BorderColor = temp.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = temp.BorderWidth;
                Control.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating RoundedImage: " + ex);
            }
        }
    }
}