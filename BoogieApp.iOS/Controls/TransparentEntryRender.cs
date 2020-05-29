using System;
using BoogieApp.iOS.Controls;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BoogieApp.Controls.TransparentEntry), typeof(TransparentEntryRender))]
namespace BoogieApp.iOS.Controls
{
    public class TransparentEntryRender: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                if (e.OldElement == null)
                {
                    Control.Layer.CornerRadius = 20;
                  //  Control.Layer.BorderWidth = 3f;
                  //  Control.Layer.BorderColor = Color.DeepPink.ToCGColor();
                    Control.Layer.BackgroundColor = Color.White.ToCGColor();

                    Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                    Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
                }

            }
        }
    }
}
