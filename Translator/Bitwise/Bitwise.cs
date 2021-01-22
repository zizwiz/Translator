using System;
using System.IO;
using System.Windows.Forms;
using CenteredMessagebox;
using Translator.Properties;

namespace Translator
{
    public partial class Form1
    {
        int bin_num = 0;

        private void rdo_CheckChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            txtbx_binary_result.Clear();
            txtbx_decimal_2.Clear();
            txtbx_decimal_1.Clear();
            txtbx_decimal_result.Clear();

            try
            {
                // Convert the binary inputs into integers.
                int operand1 = Convert.ToInt32(txtbx_bin_1.Text, 2);
                int operand2 = Convert.ToInt32(txtbx_bin_2.Text, 2);

                // Calculate the result.
                int result = 0;

                if (rdobtn_and.Checked)
                {
                    result = (operand1 & operand2);
                }
                else if (rdobtn_or.Checked)
                {
                    result = (operand1 | operand2);
                }
                else if (rdobtn_xor.Checked)
                {
                    result = (operand1 ^ operand2);
                }
                else if (rdobtn_shift_left.Checked)
                {
                    result = (operand1 << operand2);
                }
                else if (rdobtn_shift_right.Checked)
                {
                    result = (operand1 >> operand2);
                }
                else if (rdobtn_complement.Checked)
                {
                    result = ~operand1;
                }
                else
                {
                    MsgBox.Show("Check the data as I cannot work it out", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                // Display the result in binary.
                txtbx_binary_result.Text = Convert.ToString(result, 2);

                // Show the values in decimal.
                txtbx_decimal_1.Text = operand1.ToString();
                txtbx_decimal_2.Text = operand2.ToString();
                txtbx_decimal_result.Text = result.ToString();

                txtbx_hex_1.Text = operand1.ToString("X");
                txtbx_hex_2.Text = operand2.ToString("X");
                txtbx_hex_result.Text = result.ToString("X");
            }
            catch
            {
                MsgBox.Show("Check the data as I cannot work it out", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


       
        private void txtbx_decimal_2_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(txtbx_decimal_2.Text, out bin_num);

             txtbx_bin_2.Text = Convert.ToString(bin_num, 2);  
             txtbx_hex_2.Text = bin_num.ToString("X");
             Calculate();
        }


        private void txtbx_decimal_1_Leave(object sender, EventArgs e)
        {
            Int32.TryParse(txtbx_decimal_1.Text, out bin_num);

            txtbx_bin_1.Text = Convert.ToString(bin_num, 2);
            txtbx_hex_1.Text = bin_num.ToString("X");
            Calculate();
        }

        private void txtbx_hex_1_Leave(object sender, EventArgs e)
        {
            bin_num = int.Parse(txtbx_hex_1.Text, System.Globalization.NumberStyles.HexNumber);

            txtbx_bin_1.Text = Convert.ToString(bin_num, 2);
            txtbx_decimal_1.Text = bin_num.ToString("X");
            Calculate();
        }

        private void txtbx_hex_2_Leave(object sender, EventArgs e)
        {
            bin_num = int.Parse(txtbx_hex_2.Text, System.Globalization.NumberStyles.HexNumber);

            txtbx_bin_2.Text = Convert.ToString(bin_num, 2);
            txtbx_decimal_2.Text = bin_num.ToString("X");
            Calculate();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }


        private void LoadBitwiseInfo()
        {


            byte[] MHT = Resources.bitwise;

            MemoryStream ms = new MemoryStream(MHT);

            //Create File From Binary of resources folders
            FileStream f = new FileStream("bitwise.mht", FileMode.OpenOrCreate);

            //Write Bytes into Our Created helpFile.mht
            ms.WriteTo(f);
            f.Close();
            ms.Close();

            wbrwsr_bitwise.Navigate(Path.GetFullPath(Path.Combine(Application.StartupPath, ".\\bitwise.mht")));

        }

    }
}
