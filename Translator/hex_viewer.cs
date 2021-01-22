using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Translator
{
    public partial class Form1
    {

        public void SetText(byte[] Bytes)
        {
            StringBuilder SB0 = new StringBuilder();
            StringBuilder SB1 = new StringBuilder();
            int N = 0;
            rchtxbx_output.Font = new Font(FontFamily.GenericMonospace, 8); //Set font to be legible
            rchtxbx_output.SelectionColor = Color.Blue;
            rchtxbx_output.AppendText("          00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\n");

            while (N < Bytes.Length)
            {
                string Line = (Convert.ToString(N, 16).PadLeft(8, '0') + " ").ToUpper();
                SB0.Length = 0;
                SB1.Length = 0;
                for (int I = 0; I <= 1; I++) //change "I" value for number of bytes per line
                {
                    for (int J = 0; J <= 7; J++)
                    {
                        if (N >= Bytes.Length)
                        {
                            SB0.Append("   ");
                        }
                        else
                        {
                            SB0.Append((Convert.ToString(Bytes[N], 16).ToUpper()).PadLeft(2, '0') + " ");
                            SB1.Append(((Bytes[N] > 31 & Bytes[N] < 129) ? ((char)Bytes[N]).ToString() : "."));
                        }
                        N += 1;
                    }
                }
                rchtxbx_output.SelectionColor = Color.Blue;
                rchtxbx_output.AppendText(Line + (" "));
                rchtxbx_output.SelectionColor = Color.Black;
                rchtxbx_output.AppendText(SB0.ToString() + (" ") + SB1.ToString() + "\r");
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                rchtxbx_output.Clear();
                SetText(File.ReadAllBytes(OFD.FileName));
            }
        }
        
        private void btn_clear_hex_Click(object sender, EventArgs e)
        {
            rchtxbx_output.Clear();
        }

        private void rchtxbx_output_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxbx_output);
            }
        }

        
    }
}


