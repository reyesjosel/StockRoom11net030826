using System.Drawing.Drawing2D;

namespace MyStuff11net
{
    static class GraphicsExtension
    {
        // RectangleEdgeFilter enum holds only six values:
        public enum RectangleEdgeFilter
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        private static GraphicsPath GenerateRoundedRectangle(this Graphics graphics, RectangleF rectangle, float radius)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                path.AddArc(arc, 180, 90);
                arc.X = rectangle.Right - diameter;
                path.AddArc(arc, 270, 90);
                arc.Y = rectangle.Bottom - diameter;
                path.AddArc(arc, 0, 90);
                arc.X = rectangle.Left;
                path.AddArc(arc, 90, 90);
                path.CloseFigure();
            }
            return path;
        }

        private static GraphicsPath GenerateCapsule(this Graphics graphics, RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(baseRect);
            }
            catch { path.AddEllipse(baseRect); }
            finally { path.CloseFigure(); }
            return path;
        }


        /// <summary>
        /// Draws a rounded rectangle specified by a rectangle and the radius
        /// for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
        /// <param name="rectangle">The rectangle used.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on DrawRoundedRectangle</param>
        /// <param name="pen">todo: describe pen parameter on DrawRoundedRectangle</param>
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, float radius)
        {
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius 
        /// for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="width">Width of the rectangle to draw.</param>
        /// <param name="height">Height of the rectangle to draw.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on DrawRoundedRectangle</param>
        /// <param name="pen">todo: describe pen parameter on DrawRoundedRectangle</param>
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius 
        /// for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="width">Width of the rectangle to draw.</param>
        /// <param name="height">Height of the rectangle to draw.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on DrawRoundedRectangle</param>
        /// <param name="pen">todo: describe pen parameter on DrawRoundedRectangle</param>
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, int x, int y, int width, int height, int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }

        /// <summary>
        /// Fills the interior of a rounded rectangle specified by a rectangle
        /// and the radius for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Brush that determines the characteristics of the fill.</param>
        /// <param name="rectangle">The rectangle used for the edges.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on FillRoundedRectangle</param>
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, RectangleF rectangle, float radius)
        {
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Fills the interior of a rounded rectangle specified by a pair of coordinates, a width, a height
        /// and the radius for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Brush that determines the characteristics of the fill.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="width">Width of the rectangle to fill.</param>
        /// <param name="height">Height of the rectangle to fill.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on FillRoundedRectangle</param>
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Fills the interior of a rounded rectangle specified by a pair of coordinates, a width, a height
        /// and the radius for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Brush that determines the characteristics of the fill.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="width">Width of the rectangle to fill.</param>
        /// <param name="height">Height of the rectangle to fill.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>
        /// <param name="graphics">todo: describe graphics parameter on FillRoundedRectangle</param>
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, int x, int y, int width, int height, int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }

        /*
         * The brush is an instance of the System.Drawing.Brush object that would define the color of the rectangle's fill
         * and finally arcRadius which is the radius of the arc that creates all the rounded edges of the rectangle.
         * You probably would never need to remember this method ever again as it would always come up in the IntelliSense
         * for the System.Drawing.Graphics class.
         * 
         * System.Drawing.Graphics g = CreateGraphics();
         * g.FillRoundedRectangle(brush, x, y, width, height, arcRadius);
         * 
         * You can also use another method offered to create the border of a rounded rectangle only
         * 
         * g.DrawRoundedRectangle(pen, x, y, width, height, arcRadius);
         * 
         */

        class OthesTips
        {
            //This is an experimental technique, and while I can use it to get a very good looking rounded-rectangular UserControl,
            //which displays the rounded corners at DesignTime, it does not resize properly at DesignTime.

            //If you use this technique, set the BorderStyle of the UserControl to 'None.' If I can achieve proper DesignTime resize,
            //and/or BorderStyle, I'll post that here.

            //Arun's GraphicExtensions Class in Plasmoid.Extensions provides a powerful way to generate a rounded-rectangular Path.

            //By converting that Path into a Region, and setting the Region of a UserControl to that Region, you have a much
            //'leaner and meaner' way of giving it rounded-edges than messing around with 'OwnerDraw,' and the 'Paint' event.

            //I wanted to use Arun's great code to create a UserControl with Rounded corners: this is what I did to use it:

            //1. added a reference to my UserControl .cs file to Arun's NameSpace, and you'll also need a reference to the Drawing2D NameSpace:

            //using Plasmoid.Extensions;
            //using System.Drawing.Drawing2D;

            //2. changed the access modifier to the 'GenerateRoundedRectangle' method from private to public, so it now reads as:

            public static GraphicsPath GenerateRoundedRectangle()
            {

                //3. In the constructor of the UserControl, after the call to 'IntializeComponent()' ... added this code:

                GraphicsPath p = new GraphicsPath();

                /*        Graphics g = CreateGraphics();

                        // using optional named parameter style for clarity
                        p = g.GenerateRoundedRectangle
                        (
                            rectangle: Bounds,
                            radius: 10.0F,
                            filter: GraphicsExtension.RectangleEdgeFilter.All
                        );

                        Region = new Region(p);
                */
                //Only for test...
                return p;
            }

            //Note: since some WinForm controls placed on my UserControl came near the rounded-edges, and were clipped,
            //I found it expedient to increase the 'Padding' value of the UserControl.
        }
    }
}