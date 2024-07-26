using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MPA_Creative
{
    public partial class MainUI : Form
    {

        bool isMoverEnabled = false;
        Point moverLastLocation;

        int codeLastHeight;
        Point codeLastLoaction;
        bool codeResizerEnable = false;

        int propertyLastWidth;
        Point propertyLastLoaction;
        bool propertyResizerEnable = false;

        bool controlAdderMode = false;
        Control controlToAdd;

        //Active controls data
        public string activeControl = "";
        public string lastCodes = "";
        public string activeTemplate = "";
        public string activeProperty = "";
        public Control activeCtrl;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public int PixelWidthToLineWidth(int PixelWidth)
        {
            return ((PixelWidth - 5) / 6);
        }

        public int PixelHeightToLineHeight(int PixelHeight)
        {
            return ((PixelHeight - 5) / 13);
        }

        public int LineWidthToPixelWidth(int LineWidth)
        {
            return ((LineWidth * 6) + 5);
        }

        public int LineHeightToPixelHeight(int LineHeight)
        {
            return ((LineHeight * 13) + 5);
        }

        public bool IsLineWidth(int PixelWidth)
        {
            int widRemain = 0;
            Math.DivRem((PixelWidth - 5), 6, out widRemain);
            if (widRemain == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLineHeight(int PixelHeight)
        {
            int widRemain = 0;
            Math.DivRem((PixelHeight - 5), 13, out widRemain);
            if (widRemain == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LoadControlProperties(string controlName)
        {
            string ctrlTemplate = File.ReadAllText(@"Templates\" + controlName + ".mpa");
        }

        public MainUI()
        {
            InitializeComponent();

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            toolStripComboBox1.SelectedIndex = 0;
            lastCodes = generatedCodesTb.Text = File.ReadAllText(@"Templates\Default Codes.mpa");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to quit the Designer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            moverLastLocation = e.Location;
            isMoverEnabled = true;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoverEnabled)
            {
                this.Location = new Point((this.Location.X - moverLastLocation.X) + e.X, (this.Location.Y - moverLastLocation.Y) + e.Y);
                this.Update();
            }

           
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            isMoverEnabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            label6_Click(sender, e);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            _formTitle.Text = toolStripTextBox1.Text;
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            int wid = 800;
            int hei = 450;
            try
            {
                string puretest = toolStripTextBox2.Text.Replace(" ", "");
                wid = Convert.ToInt32(puretest.Split(',')[0]);
                hei = Convert.ToInt32(puretest.Split(',')[1]);
            }
            catch (Exception)
            {

            }
            
            _formBorder.Size = new Size(wid, hei + panel3.Height);
        }

        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _allControlsContainer.BackColor = ColorTranslator.FromHtml(toolStripTextBox3.Text);
            }
            catch (Exception)
            {
                _allControlsContainer.BackColor = Color.White;
            }
        }

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _allControlsContainer.BackgroundImage = Image.FromFile(toolStripTextBox4.Text);
            }
            catch(Exception)
            {
                _allControlsContainer.BackgroundImage = null;
            }
           
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                panel3.Visible = true;
            }
            else if (toolStripComboBox1.SelectedIndex == 1)
            {
                panel3.Visible = false;
            }
        }

        private void toolStripTextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(toolStripTextBox5.Text.Replace("%", "").Replace(" ", "")) >= 99)
                {
                    this.Opacity = 1;
                }
                else
                {
                    double opac = Double.Parse("0." + toolStripTextBox5.Text.Replace("%", "").Replace(" ", ""));
                    this.Opacity = opac;
                }
            }
            catch(Exception)
            {
                this.Opacity = 1;
            }
        }

        private void codeWindowResizer_MouseDown(object sender, MouseEventArgs e)
        {
            codeLastHeight = codePnl.Height;
            codeLastLoaction = Cursor.Position;
            codeResizerEnable = true;
        }

        private void codeWindowResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (codeResizerEnable)
            {
                int IncHei = codeLastLoaction.Y - Cursor.Position.Y;
                codePnl.Size = new Size(codePnl.Width, codeLastHeight + IncHei);
            }
        }

        private void codeWindowResizer_MouseUp(object sender, MouseEventArgs e)
        {
            codeResizerEnable = false;
        }

        private void propertyPnlResizer_MouseDown(object sender, MouseEventArgs e)
        {
            propertyLastWidth = propertiesPnl.Width;
            propertyLastLoaction = Cursor.Position;
            propertyResizerEnable = true;
        }

        private void propertyPnlResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (propertyResizerEnable)
            {
                int IncWid = propertyLastLoaction.X - Cursor.Position.X;
                propertiesPnl.Size = new Size(propertyLastWidth + IncWid, propertiesPnl.Height);
            }
        }

        private void propertyPnlResizer_MouseUp(object sender, MouseEventArgs e)
        {
            propertyResizerEnable = false;
        }

        private void button_layer_select_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to save previous scripts and add a new control ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                foreach (Control ctrl in _allControlsContainer.Controls)
                {
                    if (ctrl is _LayerButton)
                    {
                        _LayerButton lbtn = ctrl as _LayerButton;
                        lbtn.SaveControl();
                    }
                }

                lastCodes = generatedCodesTb.Text;
                _LayerButton lb = new _LayerButton(this);
                controlAdderMode = true;
                controlToAdd = lb;
                _allControlsContainer.Cursor = Cursors.Cross;
            }
        }

        private void _allControlsContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (controlAdderMode)
            {
                activeControl = controlToAdd.GetType().ToString();
                activeCtrl = controlToAdd;
                _allControlsContainer.Controls.Add(controlToAdd);
                controlToAdd.Location = e.Location;
                controlAdderMode = false;
                _allControlsContainer.Cursor = Cursors.Default;

                string propertyData = File.ReadAllText(@"Properties\" + controlToAdd.GetType().ToString() + ".mpa");
                properties.Rows.Clear();
                string formatTempData = File.ReadAllText(@"Templates\" + controlToAdd.GetType().ToString() + ".mpa");
                activeTemplate = formatTempData;
                activeProperty = propertyData;
                foreach (string curProp in propertyData.Split('\n'))
                {
                    var propdata = curProp.Split(new[] { '|' }, 2);
                    properties.Rows.Add(propdata[0], propdata[1]);
                    formatTempData = formatTempData.Replace("<%" + propdata[0] + "%>", propdata[1].Replace("\r", ""));
                }

                foreach (DataGridViewRow row in properties.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "X-Location")
                    {
                        row.Cells[1].Value = controlToAdd.Location.X.ToString();
                    }

                    if (row.Cells[0].Value.ToString() == "Y-Location")
                    {
                        row.Cells[1].Value = controlToAdd.Location.Y.ToString();
                    }
                }

                generatedCodesTb.Text = lastCodes + "\n\n" + formatTempData;
                ReGenerateCodes();
            }
        }

        public void ReGenerateCodes()
        {
            string dataToWrite = activeTemplate;
            _LayerButton lbtn = activeCtrl as _LayerButton;

            int height = 10;
            int width = 10;

            string font = "Microsoft Sans Serif";
            float fontsize = 10;
            FontStyle fontstyle = FontStyle.Regular;

            foreach (DataGridViewRow row in properties.Rows)
            {
                if (activeCtrl is _LayerButton)
                {
                    if (row.Cells[0].Value.ToString() == "Text")
                    {
                        lbtn.button1.Text = row.Cells[1].Value.ToString().Replace("\r", "");
                    }

                    if (row.Cells[0].Value.ToString() == "Width")
                    {
                        width = Convert.ToInt32(row.Cells[1].Value.ToString().Replace("\r", ""));
                        lbtn.Size = new Size(width, height);
                    }

                    if (row.Cells[0].Value.ToString() == "Height")
                    {
                        height = Convert.ToInt32(row.Cells[1].Value.ToString().Replace("\r", ""));
                        lbtn.Size = new Size(LineWidthToPixelWidth(width), LineHeightToPixelHeight(height));
                    }
                    
                    if (row.Cells[0].Value.ToString() == "Back Color")
                    {
                        lbtn.button1.BackColor = ColorTranslator.FromHtml(row.Cells[1].Value.ToString().Replace("\r", ""));
                    }

                    if (row.Cells[0].Value.ToString() == "Fore Color")
                    {
                        lbtn.button1.ForeColor = lbtn.defaultColor = ColorTranslator.FromHtml(row.Cells[1].Value.ToString().Replace("\r", ""));
                    }

                    

                    if (row.Cells[0].Value.ToString() == "Font")
                    {
                        font = row.Cells[1].Value.ToString().Replace("\r", "");
                        lbtn.button1.Font = new Font(font, fontsize, fontstyle);
                    }

                    if (row.Cells[0].Value.ToString() == "Font Size")
                    {
                        fontsize = float.Parse(row.Cells[1].Value.ToString().Replace("\r", ""));
                        lbtn.button1.Font = new Font(font, fontsize, fontstyle);
                    }

                    if (row.Cells[0].Value.ToString() == "Style")
                    {
                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Replace("\r", "").ToLower() == "underline")
                        {
                            fontstyle = FontStyle.Underline;
                        }
                        else if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Replace("\r", "").ToLower() == "italic")
                        {
                            fontstyle = FontStyle.Italic;
                        }
                        else if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Replace("\r", "").ToLower() == "bold")
                        {
                            fontstyle = FontStyle.Bold;
                        }
                        else
                        {
                            fontstyle = FontStyle.Regular;
                        }
                        lbtn.button1.Font = new Font(font, fontsize, fontstyle);
                    }

                    if (row.Cells[0].Value.ToString() == "Border Width")
                    {
                        lbtn.button1.FlatAppearance.BorderSize = Convert.ToInt32(row.Cells[1].Value.ToString().Replace("\r", ""));
                    }

                    if (row.Cells[0].Value.ToString() == "Highlight Fore Color")
                    {
                        lbtn.hoverColor = ColorTranslator.FromHtml(row.Cells[1].Value.ToString().Replace("\r", ""));
                    }

                    if (row.Cells[0].Value.ToString() == "Highlight Back Color")
                    {
                        lbtn.button1.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(row.Cells[1].Value.ToString().Replace("\r", ""));
                    }
                }

                if (row.Cells[1].Value == null)
                {
                    dataToWrite = dataToWrite.Replace("<%" + row.Cells[0].Value.ToString() + "%>", "");
                }
                else
                {
                    dataToWrite = dataToWrite.Replace("<%" + row.Cells[0].Value.ToString() + "%>", row.Cells[1].Value.ToString().Replace("\r", ""));
                }
                
            }

            generatedCodesTb.Text =  lastCodes + "\n\n" + dataToWrite;
        }

        public void SyncPropertiesWithControl()
        {

        }

        private void properties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ReGenerateCodes();
        }

        private void properties_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void properties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReGenerateCodes();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (colourPicker.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(ColorTranslator.ToHtml(colourPicker.Color));
                MessageBox.Show("Selected color hex value copied to clipboard !", "Color copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
