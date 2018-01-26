using Foundation;
using System;
using UIKit;
using Plugin.Media;
using Tesseract.iOS;
using CoreGraphics;
using System.Drawing;

namespace VisionRead
{
    public partial class ViewControllerPrueba : UIViewController
    {
        public CoreGraphics.CGRect cropArea
        {
            get
            {
                var factor = imagenToCrop.Image.Size.Width / View.Frame.Width;
                var scale = 1 / ScrollViewFoto.ZoomScale;
                var imageFrame = imagenToCrop.imageFrame();
                var x = (ScrollViewFoto.ContentOffset.X + CropperView.Frame.X - imageFrame.X) * scale * factor;
                var y = (ScrollViewFoto.ContentOffset.Y + CropperView.Frame.Y - imageFrame.Y) * scale * factor;
                var width = CropperView.Frame.Size.Width * scale * factor;
                var height = CropperView.Frame.Size.Height * scale * factor;
                return new CoreGraphics.CGRect(x, y, width, height);
            }
        }

        public ViewControllerPrueba(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.ScrollViewFoto.MinimumZoomScale = 1;
            this.ScrollViewFoto.MaximumZoomScale = 10;
            this.ScrollViewFoto.ViewForZoomingInScrollView += (UIScrollView sv) => { return imagenToCrop; };
        }

        async partial void BtnCamera_Activated(UIBarButtonItem sender)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                var okAlertController = UIAlertController.Create("No Camera", ":( No camera available.", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                CompressionQuality = 10
            });


            //var file = await CrossMedia.Current.PickPhotoAsync();


            if (file == null)
                return;
            imagenToCrop.Image = UIImage.FromFile(file.Path);

            Console.WriteLine(imagenToCrop.Image.Orientation);
            Console.WriteLine(imagenToCrop.Image.AccessibilityFrame);


            var uiimageToCrop = imagenToCrop.Image.ScaleAndRotateImage();
            imagenToCrop.Image = uiimageToCrop;

            Console.WriteLine(imagenToCrop.Image.Orientation);
            Console.WriteLine(imagenToCrop.Image.AccessibilityFrame);
        }

        async partial void BtnCropping_Activated(UIBarButtonItem sender)
        {
            Console.WriteLine(imagenToCrop.Image.Orientation);
            Console.WriteLine(imagenToCrop.Image.AccessibilityFrame);

            var croppedCGImage = imagenToCrop.Image.CGImage.WithImageInRect(cropArea);
            var croppedImage = new UIImage(croppedCGImage);
            imagenToCrop.Image = croppedImage;
            ScrollViewFoto.ZoomScale = 1;



            TesseractApi api = new TesseractApi();
            if (await api.Init("eng"))
            {
                if (await api.SetImage(imagenToCrop.Image.ToNSData()))
                {
                    //lblTexto.Text = api.Text;
                    var okAlertController = UIAlertController.Create("Encontrado:", api.Text, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
        }

    }
}