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

[assembly: ExportRenderer(typeof(BoogieApp.Controls.WhitePicker), typeof(WhitePickerRenderer))]
namespace BoogieApp.Droid.Controls
{
    class WhitePickerRenderer :  PickerRenderer
    {
        public WhitePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (e.OldElement == null)
                {
                    //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                    var gradientDrawable = new GradientDrawable();
                    gradientDrawable.SetCornerRadius(60f);
                    // gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                    gradientDrawable.SetColor(Android.Graphics.Color.Transparent);
                    Control.SetBackground(gradientDrawable);

                    Control.SetPadding(40, Control.PaddingTop, Control.PaddingRight,
                        Control.PaddingBottom);
                }
            }
        }
    }
}