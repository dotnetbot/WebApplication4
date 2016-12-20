using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

namespace WebApplication4.Helpers
{
    public class ImagesHelper
    {

        private static Bitmap HorizontalCenterCut(Size previewSize, Bitmap image, float heightCoeff)
        {
            var newBitmap = new Bitmap(previewSize.Width, previewSize.Height);
            var graphics = Graphics.FromImage(newBitmap);
            //x is difference on horizontal to cut image
            var x = ((float)image.Width / 2) - ((float)previewSize.Width / 2) * heightCoeff;
            MakeGraphics(previewSize, graphics);
            graphics.DrawImage(image,
                               new RectangleF(-1, -1, (float)previewSize.Width + 2, (float)previewSize.Height + 2),
                               new RectangleF(x, 0f, previewSize.Width * heightCoeff, image.Height), GraphicsUnit.Pixel);
            return newBitmap;
        }

        private static Bitmap BaseImageOnCenter(Size previewSize, Bitmap image)
        {
            var newBitmap = new Bitmap(previewSize.Width, previewSize.Height);
            var x = ((float)previewSize.Width / 2) - ((float)image.Width / 2);
            var y = ((float)previewSize.Height / 2) - ((float)image.Height / 2);
            var graphics = Graphics.FromImage(newBitmap);
            MakeGraphics(previewSize, graphics);
            graphics.DrawImage(image,
                               new RectangleF(x, y, image.Width, image.Height),
                               new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            return newBitmap;
        }

        private static Bitmap VerticalTopCut(Size previewSize, Bitmap image, float widthCoeff)
        {
            var newBitmap = new Bitmap(previewSize.Width, previewSize.Height);
            var graphics = Graphics.FromImage(newBitmap);
            //calculate top heitght
            var height = previewSize.Height * widthCoeff;
            MakeGraphics(previewSize, graphics);
            graphics.DrawImage(image,
                               new RectangleF(-1, -1, (float)previewSize.Width + 2, (float)previewSize.Height + 2),
                               new RectangleF(0f, 0f, image.Width, height), GraphicsUnit.Pixel);
            return newBitmap;
        }

        private static void MakeGraphics(Size previewSize, Graphics graphics)
        {
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.FillRectangle(Brushes.White, 0, 0, previewSize.Width, previewSize.Height);
        }

        private static void SaveJpeg(string path, Bitmap image)
        {
            var Quality = 95;
            //ensure the quality is within the correct range
            if ((Quality < 0) || (Quality > 100))
            {
                //create the error message
                string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", Quality);
                //throw a helpful exception
                throw new ArgumentOutOfRangeException(error);
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentOutOfRangeException("path can't be empty");
            }

            var dirInfo = new DirectoryInfo(Path.GetDirectoryName(path));
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            //create an encoder parameter for the image quality
            var qualityParam = new EncoderParameter(Encoder.Quality, Quality);
            //get the jpeg codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            //create a collection of all parameters that we will pass to the encoder
            var encoderParams = new EncoderParameters(1);
            //set the quality parameter for the codec
            encoderParams.Param[0] = qualityParam;
            //save the image using the codec and the parameters
            image.Save(path, jpegCodec, encoderParams);
        }

        public void GetFilePreview(Stream imageStream, string fileName)
        {
            Bitmap image;
            try
            {
                image = new Bitmap(imageStream);
            }
            catch
            {
                return;
            }
            Bitmap newBitmap = null;
            var previewSize = new Size(100, 100);
            try
            {
                if ((image.Width <= previewSize.Width) && (image.Height <= previewSize.Height))
                {
                    newBitmap = BaseImageOnCenter(previewSize, image);
                    SaveJpeg(fileName, newBitmap);
                }
                else
                {

                    var widthCoeff = (float)image.Width / previewSize.Width;
                    var heightCoeff = (float)image.Height / previewSize.Height;
                    newBitmap = widthCoeff > heightCoeff
                        ? HorizontalCenterCut(previewSize, image, heightCoeff)
                        : VerticalTopCut(previewSize, image, widthCoeff);
                    SaveJpeg(fileName, newBitmap);
                }
            }
            finally
            {
                image.Dispose();
                if (newBitmap != null)
                {
                    newBitmap.Dispose();
                }
            }
        }

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        private static Dictionary<string, ImageCodecInfo> _encoders;

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        public static Dictionary<string, ImageCodecInfo> Encoders
        {
            //get accessor that creates the dictionary on demand
            get
            {
                //if the quick lookup isn't initialised, initialise it
                if (_encoders == null)
                {
                    _encoders = new Dictionary<string, ImageCodecInfo>();
                }

                //if there are no codecs, try loading them
                if (_encoders.Count == 0)
                {
                    //get all the codecs
                    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                    {
                        //add each codec to the quick lookup
                        _encoders.Add(codec.MimeType.ToLower(), codec);
                    }
                }

                //return the lookup
                return _encoders;
            }
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //do a case insensitive search for the mime type
            string lookupKey = mimeType.ToLower();

            //the codec to return, default to null
            ImageCodecInfo foundCodec = null;

            //if we have the encoder, get it to return
            if (Encoders.ContainsKey(lookupKey))
            {
                //pull the codec from the lookup
                foundCodec = Encoders[lookupKey];
            }

            return foundCodec;
        }
    }
}
