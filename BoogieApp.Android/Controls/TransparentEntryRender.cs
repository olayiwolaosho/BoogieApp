using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using BoogieApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BoogieApp.Controls.TransparentEntry), typeof(TransparentEntryRender))]
namespace BoogieApp.Droid.Controls
{
    public class TransparentEntryRender : EntryRenderer
    {
        public TransparentEntryRender(Context context) : base(context)
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
                    gradientDrawable.SetCornerRadius(20f);
                   // gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                    gradientDrawable.SetColor(Android.Graphics.Color.White);
                    Control.SetBackground(gradientDrawable);

                    Control.SetPadding(40, Control.PaddingTop, Control.PaddingRight,
                        Control.PaddingBottom);
                }
            }
        }
    }
}
