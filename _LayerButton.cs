using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPA_Creative
{
    public partial class _LayerButton : UserControl
    {
        MainUI _parent;
        public Color defaultColor = Color.Black;
        public Color hoverColor = Color.Black;

        public _LayerButton(MainUI parentUI)
        {
            InitializeComponent();
            _parent = parentUI;
            globalHooks = Hook.AppEvents();
            globalHooks.KeyDown += GlobalHooks_KeyDown;
        }

        private void GlobalHooks_KeyDown(object sender, KeyEventArgs e)
        {
            if (NS.Visible && e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete the selected Button ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _parent._allControlsContainer.Controls.Remove(this);
                    _parent.properties.Rows.Clear();
                    _parent.generatedCodesTb.Text = _parent.lastCodes;
                }
            }
        }

        IKeyboardMouseEvents globalHooks;

        Size recordedSize;
        Point recordedPoint;
        bool allResizerEnabled = false;
        bool rightResizerEnabled = false;
        bool downResizerEnabled = false;

        Point recordedLocation;
        Point changeLocation;
        bool moverEnabled = false;

        private void NWSE_MouseDown(object sender, MouseEventArgs e)
        {
            recordedSize = this.Size;
            recordedPoint = Cursor.Position;
            allResizerEnabled = true;
        }

        public void SaveControl()
        {
            NS.Visible = false;
            WE.Visible = false;
            NWSE.Visible = false;
        }

        private void NWSE_MouseMove(object sender, MouseEventArgs e)
        {
            if (NS.Visible && allResizerEnabled)
            {
                int IncHei = Cursor.Position.Y - recordedPoint.Y;
                int IncWei = Cursor.Position.X - recordedPoint.X;
                if (_parent.IsLineWidth(recordedSize.Width + IncWei))
                {
                    this.Size = new Size(recordedSize.Width + IncWei, this.Size.Height);
                }
                if (_parent.IsLineHeight(recordedSize.Height + IncHei))
                {
                    this.Size = new Size(this.Size.Width, recordedSize.Height + IncHei);
                }
            }
        }

        private void NWSE_MouseUp(object sender, MouseEventArgs e)
        {
            allResizerEnabled = false;
            foreach (DataGridViewRow row in _parent.properties.Rows)
            {
                if (row.Cells[0].Value.ToString() == "Width")
                {
                    row.Cells[1].Value = _parent.PixelWidthToLineWidth(this.Width).ToString();
                }

                if (row.Cells[0].Value.ToString() == "Height")
                {
                    row.Cells[1].Value = _parent.PixelHeightToLineHeight(this.Height).ToString();
                }
            }
        }

        private void WE_MouseDown(object sender, MouseEventArgs e)
        {
            recordedSize = this.Size;
            recordedPoint = Cursor.Position;
            rightResizerEnabled = true;
        }

        private void WE_MouseMove(object sender, MouseEventArgs e)
        {
            if (NS.Visible && rightResizerEnabled)
            {
                int IncWei = Cursor.Position.X - recordedPoint.X;
                if (_parent.IsLineWidth(recordedSize.Width + IncWei))
                {
                    this.Size = new Size(recordedSize.Width + IncWei, this.Height);
                }
            }
        }

        private void WE_MouseUp(object sender, MouseEventArgs e)
        {
            rightResizerEnabled = false;
            foreach (DataGridViewRow row in _parent.properties.Rows)
            {
                if (row.Cells[0].Value.ToString() == "Width")
                {
                    row.Cells[1].Value = _parent.PixelWidthToLineWidth(this.Width).ToString();
                }

                if (row.Cells[0].Value.ToString() == "Height")
                {
                    row.Cells[1].Value = _parent.PixelHeightToLineHeight(this.Height).ToString();
                }
            }
        }

        private void NS_MouseDown(object sender, MouseEventArgs e)
        {
            recordedSize = this.Size;
            recordedPoint = Cursor.Position;
            downResizerEnabled = true;
        }

        private void NS_MouseMove(object sender, MouseEventArgs e)
        {
            if (NS.Visible && downResizerEnabled)
            {
                int IncHei = Cursor.Position.Y - recordedPoint.Y;
                if (_parent.IsLineHeight(recordedSize.Height + IncHei))
                {
                    this.Size = new Size(this.Width, recordedSize.Height + IncHei);
                }
            }
        }

        private void NS_MouseUp(object sender, MouseEventArgs e)
        {
            downResizerEnabled = false;
            foreach (DataGridViewRow row in _parent.properties.Rows)
            {
                if (row.Cells[0].Value.ToString() == "Width")
                {
                    row.Cells[1].Value = _parent.PixelWidthToLineWidth(this.Width).ToString();
                }

                if (row.Cells[0].Value.ToString() == "Height")
                {
                    row.Cells[1].Value = _parent.PixelHeightToLineHeight(this.Height).ToString();
                }
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            changeLocation = Cursor.Position;
            recordedLocation = this.Location;
            moverEnabled = true;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (NS.Visible && moverEnabled)
            {
                Point Inc = new Point(Cursor.Position.X - changeLocation.X, Cursor.Position.Y - changeLocation.Y);
                this.Location = new Point(Inc.X + recordedLocation.X, Inc.Y + recordedLocation.Y);
            }
            this.ForeColor = hoverColor;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            moverEnabled = false;
            foreach (DataGridViewRow row in _parent.properties.Rows)
            {
                if (row.Cells[0].Value.ToString() == "X-Location")
                {
                    row.Cells[1].Value = this.Location.X.ToString();
                }

                if (row.Cells[0].Value.ToString() == "Y-Location")
                {
                    row.Cells[1].Value = this.Location.Y.ToString();
                }
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = defaultColor;
        }
    }
}
