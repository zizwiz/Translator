using System;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1 : Form
    {

        private void ASCII_table_create()
        {
            rchtxbx_ascii_table.AppendText("Dec\t");
            rchtxbx_ascii_table.AppendText("Hex\t");
            rchtxbx_ascii_table.AppendText("Binary  \t");
            rchtxbx_ascii_table.AppendText("\tASCII\t");
            rchtxbx_ascii_table.AppendText("\tDescription");
            rchtxbx_ascii_table.AppendText("\r");

            int min = 0;
            int max = 256;
            for (int i = min; i < max; i++)
            {
                // Get ASCII character.
                char c = (char)i;

                string display = "";
                string description = "";

                
                switch (i)
                {


                    case 0: { display = "NUL"; description = "null"; break; };
                    case 1: { display = "SOH"; description = "start of header"; break; };
                    case 2: { display = "STX"; description = "start of text"; break; };
                    case 3: { display = "ETX"; description = "end of text"; break; };
                    case 4: { display = "EOT"; description = "end of transmission"; break; };
                    case 5: { display = "ENQ"; description = "enquiry"; break; };
                    case 6: { display = "ACK"; description = "acknowledge"; break; };
                    case 7: { display = "BEL"; description = "bell"; break; };
                    case 8: { display = "BS"; description = "backspace"; break; };
                    case 9: { display = "HT"; description = "horizontal tab (\\t)"; break; };
                    case 10: { display = "LF"; description = "line feed (\\n)"; break; };
                    case 11: { display = "VT"; description = "vertical tab (\\v)"; break; };
                    case 12: { display = "FF"; description = "form feed (\\f)"; break; };
                    case 13: { display = "CR"; description = "enter / carriage return (\\r)"; break; };
                    case 14: { display = "SO"; description = "shift out"; break; };
                    case 15: { display = "SI"; description = "shift in"; break; };
                    case 16: { display = "DLE"; description = "data link escape"; break; };
                    case 17: { display = "DC1"; description = "device control 1"; break; };
                    case 18: { display = "DC2"; description = "device control 2"; break; };
                    case 19: { display = "DC3"; description = "device control 3"; break; };
                    case 20: { display = "DC4"; description = "device control 4"; break; };
                    case 21: { display = "NAK"; description = "negative acknowledge"; break; };
                    case 22: { display = "SYN"; description = "synchronize"; break; };
                    case 23: { display = "ETB"; description = "end of transmission block"; break; };
                    case 24: { display = "CAN"; description = "cancel"; break; };
                    case 25: { display = "EM"; description = "end of medium"; break; };
                    case 26: { display = "SUB"; description = "substitute"; break; };
                    case 27: { display = "ESC"; description = "escape"; break; };
                    case 28: { display = "FS"; description = "file separator"; break; };
                    case 29: { display = "GS"; description = "group separator"; break; };
                    case 30: { display = "RS"; description = "record separator"; break; };
                    case 31: { display = "US"; description = "unit separator"; break; };
                    case 32: { display = "Space"; description = "space"; break; };
                    case 33: { display = "!"; description = "exclamation mark"; break; };
                    case 34: { display = "\""; description = "double quote"; break; };
                    case 35: { display = "#"; description = "number"; break; };
                    case 36: { display = "$"; description = "dollar"; break; };
                    case 37: { display = "%"; description = "percent"; break; };
                    case 38: { display = "&"; description = "ampersand"; break; };
                    case 39: { display = "'"; description = "single quote"; break; };
                    case 40: { display = "("; description = "left parenthesis"; break; };
                    case 41: { display = ")"; description = "right parenthesis"; break; };
                    case 42: { display = "*"; description = "asterisk"; break; };
                    case 43: { display = "+"; description = "plus"; break; };
                    case 44: { display = ","; description = "comma"; break; };
                    case 45: { display = "-"; description = "minus"; break; };
                    case 46: { display = "."; description = "period"; break; };
                    case 47: { display = "/"; description = "slash"; break; };
                    case 48: { display = "0"; description = "Number zero"; break; };
                    case 49: { display = "1"; description = "Number one"; break; };
                    case 50: { display = "2"; description = "Number two"; break; };
                    case 51: { display = "3"; description = "Number three"; break; };
                    case 52: { display = "4"; description = "Number four"; break; };
                    case 53: { display = "5"; description = "Number five"; break; };
                    case 54: { display = "6"; description = "Number six"; break; };
                    case 55: { display = "7"; description = "Number seven"; break; };
                    case 56: { display = "8"; description = "Number eight"; break; };
                    case 57: { display = "9"; description = "Number nine"; break; };
                    case 58: { display = ":"; description = "colon"; break; };
                    case 59: { display = ";"; description = "semicolon"; break; };
                    case 60: { display = "<"; description = "less than"; break; };
                    case 61: { display = "="; description = "equality sign"; break; };
                    case 62: { display = ">"; description = "greater than"; break; };
                    case 63: { display = "?"; description = "question mark"; break; };
                    case 64: { display = "@"; description = "at sign"; break; };
                    case 65: { display = "A"; description = "Upper Case	A"; break; };
                    case 66: { display = "B"; description = "Upper Case	B"; break; };
                    case 67: { display = "C"; description = "Upper Case	C"; break; };
                    case 68: { display = "D"; description = "Upper Case	D"; break; };
                    case 69: { display = "E"; description = "Upper Case E"; break; };
                    case 70: { display = "F"; description = "Upper Case F"; break; };
                    case 71: { display = "G"; description = "Upper Case G"; break; };
                    case 72: { display = "H"; description = "Upper Case H"; break; };
                    case 73: { display = "I"; description = "Upper Case I"; break; };
                    case 74: { display = "J"; description = "Upper Case J"; break; };
                    case 75: { display = "K"; description = "Upper Case K"; break; };
                    case 76: { display = "L"; description = "Upper Case L"; break; };
                    case 77: { display = "M"; description = "Upper Case M"; break; };
                    case 78: { display = "N"; description = "Upper Case N"; break; };
                    case 79: { display = "O"; description = "Upper Case O"; break; };
                    case 80: { display = "P"; description = "Upper Case P"; break; };
                    case 81: { display = "Q"; description = "Upper Case Q"; break; };
                    case 82: { display = "R"; description = "Upper Case R"; break; };
                    case 83: { display = "S"; description = "Upper Case S"; break; };
                    case 84: { display = "T"; description = "Upper Case T"; break; };
                    case 85: { display = "U"; description = "Upper Case U"; break; };
                    case 86: { display = "V"; description = "Upper Case V"; break; };
                    case 87: { display = "W"; description = "Upper Case W"; break; };
                    case 88: { display = "X"; description = "Upper Case X"; break; };
                    case 89: { display = "Y"; description = "Upper Case Y"; break; };
                    case 90: { display = "Z"; description = "Upper Case Z"; break; };
                    case 91: { display = "["; description = "left square bracket"; break; };
                    case 92: { display = "\\"; description = "backslash "; break; };
                    case 93: { display = "]"; description = "right square bracket "; break; };
                    case 94: { display = "^"; description = "caret / circumflex "; break; };
                    case 95: { display = "_"; description = "underscore "; break; };
                    case 96: { display = "`"; description = "grave / accent "; break; };
                    case 97: { display = "a"; description = "Lower case a"; break; };
                    case 98: { display = "b"; description = "Lower case b"; break; };
                    case 99: { display = "c"; description = "Lower case c"; break; };
                    case 100: { display = "d"; description = "Lower case d"; break; };
                    case 101: { display = "e"; description = "Lower case e"; break; };
                    case 102: { display = "f"; description = "Lower case f"; break; };
                    case 103: { display = "g"; description = "Lower case g"; break; };
                    case 104: { display = "h"; description = "Lower case h"; break; };
                    case 105: { display = "i"; description = "Lower case i"; break; };
                    case 106: { display = "j"; description = "Lower case j"; break; };
                    case 107: { display = "k"; description = "Lower case k"; break; };
                    case 108: { display = "l"; description = "Lower case l"; break; };
                    case 109: { display = "m"; description = "Lower case m"; break; };
                    case 110: { display = "n"; description = "Lower case n"; break; };
                    case 111: { display = "o"; description = "Lower case o"; break; };
                    case 112: { display = "p"; description = "Lower case p"; break; };
                    case 113: { display = "q"; description = "Lower case q"; break; };
                    case 114: { display = "r"; description = "Lower case r"; break; };
                    case 115: { display = "s"; description = "Lower case s"; break; };
                    case 116: { display = "t"; description = "Lower case t"; break; };
                    case 117: { display = "u"; description = "Lower case u"; break; };
                    case 118: { display = "v"; description = "Lower case v"; break; };
                    case 119: { display = "w"; description = "Lower case w"; break; };
                    case 120: { display = "x"; description = "Lower case x"; break; };
                    case 121: { display = "y"; description = "Lower case y"; break; };
                    case 122: { display = "z"; description = "Lower case z"; break; };
                    case 123: { display = "{"; description = "left curly bracket"; break; };
                    case 124: { display = "|"; description = "vertical bar"; break; };
                    case 125: { display = "}"; description = "right curly bracket"; break; };
                    case 126: { display = "~"; description = "tilde"; break; };
                    case 127: { display = "DEL"; description = "delete"; break; };
                    case 128: { display = "Ç"; description = "Majuscule C-cedilla"; break; };
                    case 129: { display = "ü"; description = "letter u with umlaut or diaeresis , u-umlaut"; break; };
                    case 130: { display = "é"; description = "letter e with acute accent or e-acute"; break; };
                    case 131: { display = "â"; description = "letter a with circumflex accent or a-circumflex"; break; };
                    case 132: { display = "ä"; description = "letter a with umlaut or diaeresis , a-umlaut"; break; };
                    case 133: { display = "à"; description = "letter a with grave accent"; break; };
                    case 134: { display = "å"; description = "letter a with a ring"; break; };
                    case 135: { display = "ç"; description = "Minuscule c-cedilla"; break; };
                    case 136: { display = "ê"; description = "letter e with circumflex accent or e-circumflex"; break; };
                    case 137: { display = "ë"; description = "letter e with umlaut or diaeresis ; e-umlauts"; break; };
                    case 138: { display = "è"; description = "letter e with grave accent"; break; };
                    case 139: { display = "ï"; description = "letter i with umlaut or diaeresis ; i-umlaut"; break; };
                    case 140: { display = "î"; description = "letter i with circumflex accent or i-circumflex"; break; };
                    case 141: { display = "ì"; description = "letter i with grave accent"; break; };
                    case 142: { display = "Ä"; description = "letter A with umlaut or diaeresis ; A-umlaut"; break; };
                    case 143: { display = "Å"; description = "Capital letter A with a ring"; break; };
                    case 144: { display = "É"; description = "Capital letter E with acute accent or E-acute"; break; };
                    case 145: { display = "æ"; description = "Latin diphthong ae in lowercase"; break; };
                    case 146: { display = "Æ"; description = "Latin diphthong AE in uppercase"; break; };
                    case 147: { display = "ô"; description = "letter o with circumflex accent or o-circumflex"; break; };
                    case 148: { display = "ö"; description = "letter o with umlaut or diaeresis ; o-umlaut"; break; };
                    case 149: { display = "ò"; description = "letter o with grave accent"; break; };
                    case 150: { display = "û"; description = "letter u with circumflex accent or u-circumflex"; break; };
                    case 151: { display = "ù"; description = "letter u with grave accent"; break; };
                    case 152: { display = "ÿ"; description = "Lowercase letter y with diaeresis"; break; };
                    case 153: { display = "Ö"; description = "Letter O with umlaut or diaeresis ; O-umlaut"; break; };
                    case 154: { display = "Ü"; description = "Letter U with umlaut or diaeresis ; U-umlaut"; break; };
                    case 155: { display = "ø"; description = "Lowercase slashed zero or empty set"; break; };
                    case 156: { display = "£"; description = "Pound sign ; symbol for the pound sterling"; break; };
                    case 157: { display = "Ø"; description = "Uppercase slashed zero or empty set"; break; };
                    case 158: { display = "×"; description = "Multiplication sign"; break; };
                    case 159: { display = "ƒ"; description = "Function sign ; f with hook sign ; florin sign"; break; };
                    case 160: { display = "á"; description = "Lowercase letter a with acute accent or a-acute"; break; };
                    case 161: { display = "í"; description = "Lowercase letter i with acute accent or i-acute"; break; };
                    case 162: { display = "ó"; description = "Lowercase letter o with acute accent or o-acute"; break; };
                    case 163: { display = "ú"; description = "Lowercase letter u with acute accent or u-acute"; break; };
                    case 164: { display = "ñ"; description = "eñe, enie, spanish letter enye, lowercase n with tilde"; break; };
                    case 165: { display = "Ñ"; description = "Spanish letter enye, uppercase N with tilde, EÑE, enie"; break; };
                    case 166: { display = "ª"; description = "feminine ordinal indicator"; break; };
                    case 167: { display = "º"; description = "masculine ordinal indicator"; break; };
                    case 168: { display = "¿"; description = "Inverted question marks"; break; };
                    case 169: { display = "®"; description = "Registered trademark symbol"; break; };
                    case 170: { display = "¬"; description = "Logical negation symbol"; break; };
                    case 171: { display = "½"; description = "One half"; break; };
                    case 172: { display = "¼"; description = "Quarter, one fourth"; break; };
                    case 173: { display = "¡"; description = "Inverted exclamation marks"; break; };
                    case 174: { display = "«"; description = "Angle quotes, guillemets, right-pointing quotation mark"; break; };
                    case 175: { display = "»"; description = "Guillemets, angle quotes, left-pointing quotation marks"; break; };
                    case 176: { display = "░"; description = "Graphic character, low density dotted"; break; };
                    case 177: { display = "▒"; description = "Graphic character, medium density dotted"; break; };
                    case 178: { display = "▓"; description = "Graphic character, high density dotted"; break; };
                    case 179: { display = "│"; description = "Box drawing character single vertical line"; break; };
                    case 180: { display = "┤"; description = "Box drawing character single vertical and left line"; break; };
                    case 181: { display = "Á"; description = "Capital letter A with acute accent or A-acute"; break; };
                    case 182: { display = "Â"; description = "Letter A with circumflex accent or A-circumflex"; break; };
                    case 183: { display = "À"; description = "Letter A with grave accent"; break; };
                    case 184: { display = "©"; description = "Copyright symbol"; break; };
                    case 185: { display = "╣"; description = "Box drawing character double line vertical and left"; break; };
                    case 186: { display = "║"; description = "Box drawing character double vertical line"; break; };
                    case 187: { display = "╗"; description = "Box drawing character double line upper right corner"; break; };
                    case 188: { display = "╝"; description = "Box drawing character double line lower right corner"; break; };
                    case 189: { display = "¢"; description = "Cent symbol"; break; };
                    case 190: { display = "¥"; description = "YEN and YUAN sign"; break; };
                    case 191: { display = "┐"; description = "Box drawing character single line upper right corner"; break; };
                    case 192: { display = "└"; description = "Box drawing character single line lower left corner"; break; };
                    case 193: { display = "┴"; description = "Box drawing character single line horizontal and up"; break; };
                    case 194: { display = "┬"; description = "Box drawing character single line horizontal down"; break; };
                    case 195: { display = "├"; description = "Box drawing character single line vertical and right"; break; };
                    case 196: { display = "─"; description = "Box drawing character single horizontal line"; break; };
                    case 197: { display = "┼"; description = "Box drawing character single line horizontal vertical"; break; };
                    case 198: { display = "ã"; description = "Lowercase letter a with tilde or a-tilde"; break; };
                    case 199: { display = "Ã"; description = "Capital letter A with tilde or A-tilde"; break; };
                    case 200: { display = "╚"; description = "Box drawing character double line lower left corner"; break; };
                    case 201: { display = "╔"; description = "Box drawing character double line upper left corner"; break; };
                    case 202: { display = "╩"; description = "Box drawing character double line horizontal and up"; break; };
                    case 203: { display = "╦"; description = "Box drawing character double line horizontal down"; break; };
                    case 204: { display = "╠"; description = "Box drawing character double line vertical and right"; break; };
                    case 205: { display = "═"; description = "Box drawing character double horizontal line"; break; };
                    case 206: { display = "╬"; description = "Box drawing character double line horizontal vertical"; break; };
                    case 207: { display = "¤"; description = "Generic currency sign"; break; };
                    case 208: { display = "ð"; description = "Lowercase letter eth"; break; };
                    case 209: { display = "Ð"; description = "Capital letter Eth"; break; };
                    case 210: { display = "Ê"; description = "Letter E with circumflex accent or E-circumflex"; break; };
                    case 211: { display = "Ë"; description = "Letter E with umlaut or diaeresis, E-umlaut"; break; };
                    case 212: { display = "È"; description = "Capital letter E with grave accent "; break; };
                    case 213: { display = "ı"; description = "Lowercase dot less i"; break; };
                    case 214: { display = "Í"; description = "Capital letter I with acute accent or I-acute"; break; };
                    case 215: { display = "Î"; description = "Letter I with circumflex accent or I-circumflex"; break; };
                    case 216: { display = "Ï"; description = "Letter I with umlaut or diaeresis ; I-umlaut"; break; };
                    case 217: { display = "┘"; description = "Box drawing character single line lower right corner"; break; };
                    case 218: { display = "┌"; description = "Box drawing character single line upper left corner"; break; };
                    case 219: { display = "█"; description = "Block, graphic character"; break; };
                    case 220: { display = "▄"; description = "Bottom half block"; break; };
                    case 221: { display = "¦"; description = "Vertical broken bar"; break; };
                    case 222: { display = "Ì"; description = "Capital letter I with grave accent"; break; };
                    case 223: { display = "▀"; description = "Top half block"; break; };
                    case 224: { display = "Ó"; description = "Capital letter O with acute accent or O-acute"; break; };
                    case 225: { display = "ß"; description = "Letter Eszett ; scharfes S or sharp S"; break; };
                    case 226: { display = "Ô"; description = "Letter O with circumflex accent or O-circumflex"; break; };
                    case 227: { display = "Ò"; description = "Capital letter O with grave accent"; break; };
                    case 228: { display = "õ"; description = "Lowercase letter o with tilde or o-tilde"; break; };
                    case 229: { display = "Õ"; description = "Capital letter O with tilde or O-tilde"; break; };
                    case 230: { display = "µ"; description = "Lowercase letter Mu ; micro sign or micron"; break; };
                    case 231: { display = "þ"; description = "Lowercase letter Thorn"; break; };
                    case 232: { display = "Þ"; description = "Capital letter Thorn"; break; };
                    case 233: { display = "Ú"; description = "Capital letter U with acute accent or U-acute"; break; };
                    case 234: { display = "Û"; description = "Letter U with circumflex accent or U-circumflex"; break; };
                    case 235: { display = "Ù"; description = "Capital letter U with grave accent"; break; };
                    case 236: { display = "ý"; description = "Lowercase letter y with acute accent"; break; };
                    case 237: { display = "Ý"; description = "Capital letter Y with acute accent"; break; };
                    case 238: { display = "¯"; description = "Macron symbol"; break; };
                    case 239: { display = "´"; description = "Acute accent"; break; };
                    case 240: { display = "≡"; description = "Congruence relation symbol"; break; };
                    case 241: { display = "±"; description = "Plus-minus sign"; break; };
                    case 242: { display = "‗"; description = "underline or underscore"; break; };
                    case 243: { display = "¾"; description = "three quarters, three-fourths"; break; };
                    case 244: { display = "¶"; description = "Paragraph sign or pilcrow ; end paragraph mark"; break; };
                    case 245: { display = "§"; description = "Section sign"; break; };
                    case 246: { display = "÷"; description = "The division sign ; Obelus"; break; };
                    case 247: { display = "¸"; description = "cedilla"; break; };
                    case 248: { display = "°"; description = "Degree symbol"; break; };
                    case 249: { display = "¨"; description = "Diaresis"; break; };
                    case 250: { display = "·"; description = "Interpunct or space dot"; break; };
                    case 251: { display = "¹"; description = "Superscript one, exponent 1, first power"; break; };
                    case 252: { display = "³"; description = "Superscript three, exponent 3, cube, third power"; break; };
                    case 253: { display = "²"; description = "Superscript two, exponent 2, square, second power"; break; };
                    case 254: { display = "■"; description = "black square"; break; };
                    case 255: { display = " "; description = "No break space"; break; };

                }
                // Write table row.
                rchtxbx_ascii_table.AppendText(i.ToString() + "\t"); //decimal
                rchtxbx_ascii_table.AppendText(i.ToString("X2") + "\t"); //hex
                rchtxbx_ascii_table.AppendText(Convert.ToString(i, 2).PadLeft(8, '0') + "\t"); //binary
                rchtxbx_ascii_table.AppendText("\t" + display + "\t"); //ASCII representation
                rchtxbx_ascii_table.AppendText("\t" + description); //description
                rchtxbx_ascii_table.AppendText("\r");
            }
        }
        
    }
}
