using Foundation;
using System;
using UIKit;

namespace VisionRead
{
    public partial class ViewCroppingArea : UIView
    {
        public ViewCroppingArea (IntPtr handle) : base (handle)
        {
        }

        public override bool PointInside(CoreGraphics.CGPoint point, UIEvent uievent)
        {
            return false;
        }

    }
}