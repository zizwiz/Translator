using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using help_about;
using Translator.Properties;

namespace Translator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btn_help_Click(object sender, EventArgs e)
        {
            var f1 = new Help_Form();
            f1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ASCII items
            ASCII_table_create();


            // create the Unicode items
            grpbx_fontinfo.Visible = false;

            foreach (FontFamily oneFontFamily in FontFamily.Families)
            {
                cmbobx_fontname.Items.Add(oneFontFamily.Name);
            }

            cmbobx_fontname.SelectedIndex = 24;
            cmbobx_fontsize.SelectedIndex = 4;
            cmbobx_style.SelectedIndex = 2;

            draw_grid();
            ShowChars();

            tabControl1.SelectedIndex = 1;

            txtbx_x_radius.Text = scrXRadius.Value.ToString();
            txtbx_y_radius.Text = scrYRadius.Value.ToString();

            OriginalImage = new Bitmap(Resources.domino);
            picImage.Image = OriginalImage;
            picImage.Visible = true;
            ShowImage();

            LoadBitwiseInfo();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                this.Size = new Size(942, 729); //dynamically resize the form
                grpbx_fontinfo.Visible = true;

            }
            else
            {
                this.Size = new Size(942, 656); //dynamically resize the form
                grpbx_fontinfo.Visible = false;
            }
        }



        private void rchtxbx_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxbx_text);
            }
        }

        private void rchtxbx_unicode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxbx_unicode);
            }
        }

        private void rchtxtbx_UTF8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowMenu(rchtxtbx_UTF8);
            }
        }



        private void ShowMenu(RichTextBox WheretoShow)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem("Cut");
            menuItem.Click += new EventHandler((sender, e) => CutAction(sender, e, WheretoShow));
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Copy All");
            menuItem.Click += new EventHandler((sender, e) => CopyActionAll(sender, e, WheretoShow));
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Copy Highlighted");
            menuItem.Click += new EventHandler((sender, e) => CopyActionHighlighted(sender, e, WheretoShow));
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Paste");
            menuItem.Click += new EventHandler((sender, e) => PasteAction(sender, e, WheretoShow));
            contextMenu.MenuItems.Add(menuItem);

            WheretoShow.ContextMenu = contextMenu;
        }

        void CutAction(object sender, EventArgs e, RichTextBox WhereToCut)
        {
            WhereToCut.Cut();
        }

        private void CopyActionAll(object sender, EventArgs e, RichTextBox WhereToCopy)
        {
            if (WhereToCopy.Text != "")
            {
                Clipboard.Clear();
                Clipboard.SetText(WhereToCopy.Text); //Copy All text in box to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        private void CopyActionHighlighted(object sender, EventArgs e, RichTextBox WhereToCopy)
        {
            if (WhereToCopy.Text != "")
            {
                Clipboard.Clear();
                Clipboard.SetText(WhereToCopy.SelectedText);  //Copy Highlighted text to Clipboard
            }
            else
            {
                MessageBox.Show("Nothing to Copy");
            }
        }

        void PasteAction(object sender, EventArgs e, RichTextBox WhereToPaste)
        {
            if (Clipboard.ContainsText())
            {
                WhereToPaste.Text = Clipboard.GetText();
            }
            else
            {
                MessageBox.Show("No Text to paste");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(Path.GetFullPath(Path.Combine(Application.StartupPath, ".\\bitwise.mht")));
            wbrwsr_bitwise.Dispose();
            Dispose();
        }
    }
}
