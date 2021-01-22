using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1 : Form
    {
        private void btn_clr_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            rchtxbx_text.Clear();
            rchtxbx_unicode.Clear();
            rchtxtbx_UTF8.Clear();
        }

        private void btn_cleartxt_Click(object sender, EventArgs e)
        {
            rchtxbx_text.Clear();
        }


        private void btn_clr_unicode_Click(object sender, EventArgs e)
        {
            rchtxbx_unicode.Clear();
        }

        private void btn_clr_utf8_Click(object sender, EventArgs e)
        {
            rchtxtbx_UTF8.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_tran_text_Click(object sender, EventArgs e)
        {
            convert_ASCII_to_utf8(rchtxbx_text.Text);
            convert_ASCII_to_unicode(rchtxbx_text.Text);
        }

        private void btn_tran_unicode_Click(object sender, EventArgs e)
        {
            convert_Unicode_to_ASCII(rchtxbx_unicode.Text);
            convert_ASCII_to_utf8(rchtxbx_text.Text);
        }

        private void btn_tran_utf8_Click(object sender, EventArgs e)
        {
            convert_UTF8_to_ASCII(rchtxtbx_UTF8.Text);
            convert_ASCII_to_unicode(rchtxbx_text.Text);
        }




        private void convert_ASCII_to_unicode(string input)
        {
            //------------------------------------------------------------------------
            // Convert to 2 byte Unicode
            // The return is always 2 bytes.
            //-----------------------------------------------------------------------

            try
            {
                StringBuilder ubuilder = new StringBuilder();

                char[] stringChars = Encoding.Unicode.GetChars(Encoding.Unicode.GetBytes(rchtxbx_text.Text));

                Array.ForEach(stringChars, c => ubuilder.AppendFormat("{0:x4} ", (int)c));

                rchtxbx_unicode.SelectionFont = new System.Drawing.Font("San Serif", 20);
                rchtxbx_unicode.AppendText(ubuilder.ToString() + "\r");
            }
            catch (Exception)
            {

                MessageBox.Show("Check the Text it does not seem to be correct");
            }


        }


        private void convert_ASCII_to_utf8(string input)
        {
            //------------------------------------------------------------------------
            // Convert to UTF8
            // The return will be either 1 byte, 2 bytes or 3 bytes.
            //-----------------------------------------------------------------------
            try
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                StringBuilder builder = new StringBuilder();

                string utext = rchtxbx_text.Text;

                for (int text_index = 0; text_index < utext.Length; text_index++) //do one char at a time

                {
                    byte[] encodedBytes = utf8.GetBytes(utext.Substring(text_index, 1));

                    for (int index = 0; index < encodedBytes.Length; index++)

                    {
                        builder.AppendFormat("{0}", Convert.ToString(encodedBytes[index], 16));
                    }

                    builder.Append(" ");
                }

                rchtxtbx_UTF8.SelectionFont = new System.Drawing.Font("San Serif", 20);
                rchtxtbx_UTF8.AppendText(builder.ToString() + "\r");

            }
            catch (Exception)
            {

                MessageBox.Show("Check the Text it does not seem to be correct");
            }


        }

        private void convert_UTF8_to_ASCII(string input)
        {
            try
            {
                //split into 2 char chunks, then into bytes, then into string.
                Encoding utf8 = Encoding.UTF8;
                string utext = rchtxtbx_UTF8.Text.Replace(" ", ""); //get string and remove spaces.
                rchtxbx_text.Text =
                    Encoding.UTF8.GetString(
                        Enumerable.Range(0, utext.Length / 2)
                            .Select(i => Convert.ToByte(utext.Substring(i * 2, 2), 16))
                            .ToArray());
            }
            catch (Exception)
            {

                MessageBox.Show("Check the UTF8 it does not seem to be correct");
            }

        }

        private void convert_Unicode_to_ASCII(string input)
        {
            String utext = rchtxbx_unicode.Text.Replace(" ", ""); //get string and remove spaces.

            try
            {
                char c = ' ';

                string rtstr = "";
                for (int i = 0; i < utext.Length; i += 4)
                {
                    string str1 = utext.Substring(i, 4);
                    c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                    rtstr += c;
                }

                rchtxbx_text.Text = rtstr;
            }
            catch (Exception)
            {

                MessageBox.Show("Check the Unicode it does not seem to be correct");
            }

        }

        private void btn_text_copy_Click(object sender, EventArgs e)
        {
            if (rchtxbx_text.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(rchtxbx_text.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        private void btn_unicode_copy_Click(object sender, EventArgs e)
        {
            if (rchtxbx_unicode.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(rchtxbx_unicode.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        private void btn_utf8_copy_Click(object sender, EventArgs e)
        {
            if (rchtxtbx_UTF8.Text != "")
            {
                Clipboard.Clear(); //Clear if any old value is there in Clipboard        
                Clipboard.SetText(rchtxtbx_UTF8.Text); //Copy text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }
    }
}
