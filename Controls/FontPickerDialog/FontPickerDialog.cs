using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace StockRoom11net.Controls.FontPickerDialog
{
    public class FontPickerDialog : Form
    {
        public Font SelectedFont { get; private set; }

        private ListBox _fontList = new ListBox();
        private ListBox _sizeList = new ListBox();
        private CheckBox _bold = new CheckBox { Text = "Bold" };
        private CheckBox _italic = new CheckBox { Text = "Italic" };
        private Label _preview = new Label { Text = "Preview AaBbCc 123" };
        private Button _btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK };
        private Button _btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

        public FontPickerDialog(Font currentFont)
        {
            this.Text = "Select Font";
            this.Size = new Size(600, 500);   // ← YOUR SIZE
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Font list
            _fontList.Bounds = new Rectangle(20, 20, 280, 300);
            foreach (FontFamily f in FontFamily.Families)
                _fontList.Items.Add(f.Name);
            _fontList.SelectedItem = currentFont.FontFamily.Name;

            // Size list
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 32, 36, 48, 72 };
            _sizeList.Bounds = new Rectangle(320, 20, 80, 300);
            foreach (var s in sizes)
                _sizeList.Items.Add(s);
            _sizeList.SelectedItem = (int)currentFont.SizeInPoints;

            // Style checkboxes
            _bold.Bounds = new Rectangle(420, 20, 100, 30);
            _italic.Bounds = new Rectangle(420, 60, 100, 30);
            _bold.Checked = currentFont.Bold;
            _italic.Checked = currentFont.Italic;

            // Preview label
            _preview.Bounds = new Rectangle(20, 340, 540, 60);
            _preview.Font = currentFont;
            _preview.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            _btnOK.Bounds = new Rectangle(390, 420, 90, 35);
            _btnCancel.Bounds = new Rectangle(490, 420, 90, 35);

            // Update preview on change
            _fontList.SelectedIndexChanged += UpdatePreview;
            _sizeList.SelectedIndexChanged += UpdatePreview;
            _bold.CheckedChanged += UpdatePreview;
            _italic.CheckedChanged += UpdatePreview;

            _btnOK.Click += (s, e) => { SelectedFont = _preview.Font; this.Close(); };

            this.Controls.AddRange(new Control[]
            {
            _fontList, _sizeList, _bold, _italic, _preview, _btnOK, _btnCancel
            });

            this.AcceptButton = _btnOK;
            this.CancelButton = _btnCancel;
        }

        void UpdatePreview(object sender, EventArgs e)
        {
            if (_fontList.SelectedItem == null || _sizeList.SelectedItem == null) return;

            var style = FontStyle.Regular;
            if (_bold.Checked) style |= FontStyle.Bold;
            if (_italic.Checked) style |= FontStyle.Italic;

            _preview.Font = new Font(
                _fontList.SelectedItem.ToString(),
                (int)_sizeList.SelectedItem,
                style);
        }
    }
}
