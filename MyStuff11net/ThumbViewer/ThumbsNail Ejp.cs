using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace MyStuff11net
{
    public class ThumbsNail_Ejp
    {
        public static void GetThumbNailFromFile(string fileName)
        {
            Image image = Image.FromFile(fileName);
            Image thumbNail = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            thumbNail.Save(Path.ChangeExtension(fileName, "thumb"));
        }

        public static Bitmap CreateBitmapImage(string sImageText)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);

            objGraphics.Flush();
            objFont.Dispose();
            objGraphics.Dispose();

            return (objBmpImage);
        }


        /*   Our Windows file server has an archive service installed that "stubs" files that have not been
        accessed for a defined period of time. When a request for the stubbed file is sent to the server,
        the archive service replaces the stub with the original document and serves it to the user.
           A major complaint about the archive service was that thumbnails for photos were no longer available.
        I decided to create a program in C# that would allow the user to select a folder and unstub all the
        files in it. It does this by reading the first byte of each file in the folder:
        It works well, but I have one small problem that I would like to resolve.

        In Windows 7, when the FileStream is closed, Windows Explorer refreshes the file and shows the correct
        thumbnail, so you can see the thumbnail of each file as they are unstubbed. In Windows XP, however,
        Explorer does not refresh the files until the program exits, forcing the user to wait until all files
        have been unstubbed before being able to browse them.
            I got it working eventually. Here is the ShellNotification class that I can call refreshThumbnail(fi.FullName)
        from after unstubbing the file: pastebin.com/7VnfiKX6 It's a bit rough at the moment, but does the job.
        Other sources I used are: viewontv.codeplex.com/SourceControl/changeset/view/52406#939762 */
        public static void StubbedFile(string path)
        {
            string directory = path.Replace(Path.GetFileName(path), "");
            if (Directory.Exists(directory))
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                FileInfo[] potentiallyStubbedFiles = di.GetFiles();
                foreach (FileInfo fi in potentiallyStubbedFiles)
                {
                    //ignore Thumbs.db files
                    if (fi.Name.Equals("Thumbs.db"))
                        continue;

                    if (!MyCode.IsImageExtension(fi.Extension))
                        continue;

                    //Console.WriteLine("Reading " + fi.Name);
                    try
                    {
                        FileStream fs = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.None);

                        try
                        {
                            //read the first byte of the file, forcing it to be unstubbed
                            byte[] firstByte = new byte[1];
                            fs.ReadExactly(firstByte, 0, 1);
                        }
                        catch (Exception)
                        {
                            //Console.WriteLine("An error occurred trying to read " + fi.Name + ":");
                        }

                        fs.Close();
                    }
                    catch (Exception)
                    {
                        // Console.WriteLine("An error occurred trying to open " + fi.Name + ":");
                    }
                }
                Console.WriteLine("Finished reading files.");
            }
            else
            {
                Console.WriteLine("\"" + path + "\" is not a valid directory.");
            }
        }


    }
}
