using System;
using System.Windows.Forms;
using ConvertAll;

namespace Translator
{
    public partial class Form1
    {

        private void btn_trans_hex_Click(object sender, EventArgs e)
        {
            try
            {
                if (rchtxtbx_hex.Text != "")
                {
                    if ((rchtxtbx_hex.Text.Length % 2) == 0)
                    {
                        rchtxtbx_ascii.Text = convert.ConvertHexToString(rchtxtbx_hex.Text.Replace(" ", ""));
                    }
                    else
                    {
                        MessageBox.Show("Check input as Hex is even number of bytes.");

                    }
                }
                else
                {
                    MessageBox.Show("Nothing available to translate");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to translate hex, check it is correct");
            }

        }

        private void btn_clr_hex_Click(object sender, EventArgs e)
        {
            rchtxtbx_hex.Clear();
        }

        private void btn_cpy_hex_Click(object sender, EventArgs e)
        {

            if (rchtxtbx_hex.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(rchtxtbx_hex.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        private void btn_trans_ascii_Click(object sender, EventArgs e)
        {
            try
            {
                if (rchtxtbx_ascii.Text != "")
                {
                    rchtxtbx_hex.Text = convert.ConvertStringToHex(rchtxtbx_ascii.Text);
                }
                else
                {
                    MessageBox.Show("Nothing available to translate");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Not able ot translate Text, check it is OK");
            }

        }

        private void btn_clr_ascii_Click(object sender, EventArgs e)
        {
            rchtxtbx_ascii.Clear();
        }

        private void btn_cpy_ascii_Click(object sender, EventArgs e)
        {
            if (rchtxtbx_ascii.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(rchtxtbx_ascii.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        private void btn_clear_all_Click(object sender, EventArgs e)
        {
            rchtxtbx_hex.Clear();
            rchtxtbx_ascii.Clear();
        }


        private void rchtxtbx_hex_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxtbx_hex);
            }
        }

        private void rchtxtbx_ascii_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxtbx_ascii);
            }
        }


    }

}
