namespace MyStuff11net
{
    // Your class should look like this:
    public class DataGridViewBarGraphCell : DataGridViewTextBoxCell
    {
        Image IconPDF = Properties.Resources.Document_PDF;

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
                          int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
                          string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
                          DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, "", errorText, cellStyle,
                       advancedBorderStyle, paintParts);

            //  Get the value of the cell, If cell value is 0, you still
            //  want to show something, so set the value to 1.
            var cellValue = Convert.IsDBNull(value) ? 0 : Convert.ToInt32(value);

            if (cellValue == 0)
                cellValue = 1;

            const int horizontaloffset = 1;
            const int spacer = 2;

            //  Get the parent column and the maximum value:
            var parent = (DataGridViewBarGraphColumn)OwningColumn;

            // Calculate the maximum value in the parent
            // column. This code only runs once, but it
            // needs to be called from a location in which
            // you know the data binding has completed:
            if (parent.NeedcsRecalc)
                parent.CalcMaxValue();

            var fnt = parent.InheritedStyle.Font;
            var maxValueSize = graphics.MeasureString(parent.MaxValue.ToString(), fnt);
            var availableWidth = cellBounds.Width - (maxValueSize.Width + 15) - spacer - (horizontaloffset * 2);

            double rectXValue;
            double cell_Max;

            if (parent.MaxValue != 0)
            {
                cell_Max = (double)cellValue / parent.MaxValue;
                rectXValue = cell_Max * availableWidth;
            }
            else
                rectXValue = 0;

            const int vertoffset = 4;

            var newRect = new RectangleF(cellBounds.X + horizontaloffset, cellBounds.Y + vertoffset,
                                             (Convert.ToSingle(rectXValue)), cellBounds.Height - (vertoffset * 2));

            var red = (cellValue / 255) * 100;
            if (red < 0)
                red = 0;
            if (red > 255)
                red = 255;

            var _brush = new SolidBrush(Color.FromArgb(255, red, 255 - red, 0));

            //graphics.FillRectangle(_brush, newRect);

            var pt = new Point((cellBounds.Left + 3), (cellBounds.Location.Y + 3));

            graphics.DrawImage(IconPDF, pt);


            #region"Process String cellText and textPosition"

            // var cellText = decimal.Round(cellValue, 2).ToString();
            var cellText = cellValue.ToString();

            var textSize = graphics.MeasureString(cellText, fnt);

            //  Calculate where text would start:
            //var textStart = new PointF(Convert.ToSingle(horizontal offset + cellValue + spacer),(cellBounds.Height - textSize.Height)/2);
            var textStart = new PointF(Convert.ToSingle(horizontaloffset + newRect.Width + spacer), (cellBounds.Height - textSize.Height) / 2);

            //  Calculate the correct color:
            var textColor = parent.InheritedStyle.ForeColor;

            if ((cellState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                textColor = parent.InheritedStyle.SelectionForeColor;

            // Draw the text:
            using (var brush = new SolidBrush(textColor))
            {
                graphics.DrawString(cellText, fnt, brush, cellBounds.X + textStart.X, cellBounds.Y + textStart.Y);
            }

            #endregion
        }
    }
}
