#region Namespace Inclusions
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Translator
{

    #region Public Enumerations
    public enum DataMode { Text, Hex }
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error, Data };
    #endregion


    public partial class Form1 : Form
    {

        #region Local Variables

            // The main control for communicating through the RS-232 port
           // private SerialPort serialPort1 = new SerialPort();

            // The main control for communicating through the Ethernet port
            //TcpClient tcpclnt = new TcpClient();

            // Various colors for logging info
            private Color[] LogMsgTypeColor = { Color.FromArgb(0,255,255), Color.FromArgb(127,255,0), Color.FromArgb(255,255,255), Color.FromArgb(255,255,0), Color.FromArgb(255,0,0), Color.FromArgb(255,0,255) };

            //private Settings settings = Settings.Default;

        #endregion


            //clear contents of rich text box
            private void ClearTerminal()
            {
                rchtxtbx_ascii.Clear();
            }    
        


        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            
                s = s.Replace(" ", "");
                byte[] buffer = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
                return buffer;
            
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2} ", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            HexValue = HexValue.Replace(" ", "");
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;
        }

       



        /// <summary> Log data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        public void Log(LogMsgType msgtype, string msg)
        {
                rchtxtbx_ascii.Invoke(new EventHandler(delegate
                {
                    rchtxtbx_ascii.SelectedText = string.Empty;
                    rchtxtbx_ascii.SelectionFont = new Font(rchtxtbx_ascii.SelectionFont, FontStyle.Bold);
                    rchtxtbx_ascii.SelectionColor = LogMsgTypeColor[(int)msgtype];
                    rchtxtbx_ascii.AppendText(msg);
                    rchtxtbx_ascii.ScrollToCaret();

                }));
            
         }

   
        
    }
}
          