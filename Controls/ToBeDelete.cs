using System;
using System.Collections.Generic;
using System.Text;

namespace StockRoom11net.Controls
{
    internal class ToBeDelete
    {
        /*

        #region"Manually draw sort glyph"

            // required because EnableHeadersVisualStyles=false
            // disables the built-in glyph rendering.
            if (_dataGridView.SortedColumn != null &&
                _dataGridView.SortedColumn.Index == e.ColumnIndex &&
                _dataGridView.SortOrder != SortOrder.None)
            {
                bool ascending = _dataGridView.SortOrder == SortOrder.Ascending;

        // Scale glyph to column header height.
        int glyphHeight = Math.Max(4, e.CellBounds.Height / 3);
        int glyphWidth = glyphHeight * 2;                      // keep equilateral-ish ratio
        int glyphX = e.CellBounds.Right - glyphWidth - 6;      // right-aligned with margin
        int glyphCenterY = e.CellBounds.Top + e.CellBounds.Height / 2;

        Point[] triangle = ascending  // ▲
            ? new Point[]
            {
                        new Point(glyphX,              glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY - glyphHeight / 2)
            }
            : new Point[]             // ▼
            {
                        new Point(glyphX,              glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY + glyphHeight / 2)
            };

        e.Graphics.FillPolygon(Brushes.Black, triangle);
                offsetX = glyphWidth + 10;   // replaces the hardcoded offsetX = 25 when sort glyph is present, to maintain
                                             // consistent spacing between the filter icon and the right edge of the cell.
            }
            else
            {
                offsetX = iconSize + 4;   // was: offsetX = 10
            }

            #endregion"Manually draw sort glyph"

            */


    }
}
