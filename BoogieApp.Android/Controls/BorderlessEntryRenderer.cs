using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BoogieApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(BoogieApp.Controls.BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace BoogieApp.Droid.Controls
{
    class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (e.OldElement == null)
                {
                    //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                    var gradientDrawable = new GradientDrawable();
                    gradientDrawable.SetCornerRadius(10f);
                    // gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                    gradientDrawable.SetColor(Android.Graphics.Color.Rgb(255, 255, 255));
                    Control.SetBackground(gradientDrawable);

                    Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                        Control.PaddingBottom);
                }
            }
        }
    }
}