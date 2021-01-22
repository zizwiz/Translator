using System;
using System.Text;

namespace Translator
{
    public partial class Form1
    {
        private void btn_dectohex_Click(object sender, EventArgs e)
        {

            float val = float.Parse(txtbx_decimal.Text);

            byte[] b = BitConverter.GetBytes(val);

            Array.Reverse(b);

            StringBuilder sb = new StringBuilder();

            foreach (byte by in b)
                sb.Append(by.ToString("X2"));

            txtbx_floating_hex.Text = sb.ToString();

        }

        private void btn_hextodec_Click(object sender, EventArgs e)
        {
            string hexString = txtbx_floating_hex2.Text;
            uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);

            txtbx_decimal2.Text = f.ToString();
        }
    }
}
