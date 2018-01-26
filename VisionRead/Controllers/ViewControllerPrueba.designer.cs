// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VisionRead
{
    [Register ("ViewControllerPrueba")]
    partial class ViewControllerPrueba
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnCropping { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        VisionRead.ViewCroppingArea CropperView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imagenToCrop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollViewFoto { get; set; }

        [Action ("BtnCamera_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCamera_Activated (UIKit.UIBarButtonItem sender);

        [Action ("BtnCropping_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCropping_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCamera != null) {
                btnCamera.Dispose ();
                btnCamera = null;
            }

            if (btnCropping != null) {
                btnCropping.Dispose ();
                btnCropping = null;
            }

            if (CropperView != null) {
                CropperView.Dispose ();
                CropperView = null;
            }

            if (imagenToCrop != null) {
                imagenToCrop.Dispose ();
                imagenToCrop = null;
            }

            if (ScrollViewFoto != null) {
                ScrollViewFoto.Dispose ();
                ScrollViewFoto = null;
            }
        }
    }
}