using System;
using System.Drawing;
using System.Globalization;
using System.Unicode;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1
    {
        private void btn_go_Click(object sender, EventArgs e)
        {
            ShowChars();
        }

        private void draw_grid()
        {

            dGV_glyphs_page.ColumnCount = 16;
            
            //Create Columns with header
            for (int k = 0; k < 16; k++)
            {
                dGV_glyphs_page.Columns[k].Name = k.ToString("X1");
                //dGV_glyphs_page.Columns[k].Width = 60;
            }

            //Add rows
            for (int i = 0; i < 16; i++)
            {
                dGV_glyphs_page.Rows.Add();
            }

            //add names of rows.
            for (int j = 0; j < 16; j++)
            {
                dGV_glyphs_page.Rows[j].HeaderCell.Value = j.ToString("X1");
                dGV_glyphs_page.RowHeadersWidth = 60;
                dGV_glyphs_page.Rows[j].Height = 50;
            }

            this.dGV_glyphs_page.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dGV_glyphs_page_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = "";

            if ((e.ColumnIndex) >= 0 && (e.RowIndex >= 0))
            {
                name =
                    UnicodeInfo.GetName(
                        Convert.ToInt32(dGV_glyphs_page.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString(), 16));


                MessageBox.Show(dGV_glyphs_page.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString() + " = " +
                                dGV_glyphs_page.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " = " + name);
            }
        }

        private void dGV_glyphs_page_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                    txtbx_text.Text = txtbx_text.Text + dGV_glyphs_page[e.ColumnIndex, e.RowIndex].Value;
            }
        }

        private void ShowChars()
        {

            var num = -1;
            string myHex = "";

            dGV_glyphs_page.Rows.Clear();
            dGV_glyphs_page.Refresh();
            draw_grid();


            // get the font name and style
            FontFamily fname = new FontFamily(cmbobx_fontname.Text);
            FontStyle fs = FontStyle.Regular;
            Font font;

            FontStyle fstyle = (FontStyle)Enum.Parse(typeof(FontStyle), cmbobx_style.Text, true);

            //Check if we can draw it if not chnage its style
            if (fname.IsStyleAvailable(fstyle))
            {
               
                dGV_glyphs_page.DefaultCellStyle.Font = new Font(cmbobx_fontname.Text,
                    float.Parse(cmbobx_fontsize.Text, CultureInfo.InvariantCulture.NumberFormat), fstyle);
                dGV_glyphs_page.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                try
                {
                    for (int i = 0; i < 16; i++)
                    {

                        for (int j = 0; j < 16; j++)
                        {
                            num = num + 1;
                            myHex = num.ToString("X2");

                            dGV_glyphs_page.Rows[i].Cells[j].Value =
                                char.ConvertFromUtf32(int.Parse((txtbx_page.Text + myHex),
                                    System.Globalization.NumberStyles.HexNumber));
                            dGV_glyphs_page.Rows[i].Cells[j].Tag = txtbx_page.Text.ToUpper() + myHex;

                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something is not right check you have the\rcorrect page or font Family selected");
                }

            }
            else
            {
                MessageBox.Show("The style " + cmbobx_style.Text + " is not supported by the font " + cmbobx_fontname.Text + "\rTry a different font Style");
            }

            dGV_glyphs_page.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btn_txt_clr_Click(object sender, EventArgs e)
        {
            txtbx_text.Text = "";
            
        }

        private void btn_copy_txt_Click(object sender, EventArgs e)
        {
            if (txtbx_text.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(txtbx_text.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("No text to copy");
            }
        }
    }
}
