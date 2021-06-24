using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        string filename;
        bool change = false;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt|*.txt|All FILE|*.*";
            if (change == true)
            {
                DialogResult br = MessageBox.Show("Do you want save your Result?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (br == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName != "")
                    {
                        richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                        change = false;
                        this.Text = "Notepad";
                    }
                }
                else if (br == DialogResult.No)
                {
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName != "")
                    {
                        richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                        filename = openFileDialog1.FileName;
                        change = false;
                        this.Text = "Notepad";
                    }
                }
            }
            else
            {

                openFileDialog1.ShowDialog();
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                filename = openFileDialog1.FileName;
                change = false;
                this.Text = "Notepad";
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") ;
            {
                System.IO.File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
                filename = saveFileDialog1.FileName;
                change = false;
                this.Text = "Notepad";
            }
        }


     

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename == "")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(filename, richTextBox1.Text);
                change = false;
                this.Text = "Notepad";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (change == true)
            {
                DialogResult br = MessageBox.Show("Do you want save your Result?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (br == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    richTextBox1.Text = "";
                    change = false;
                    this.Text = "Notepad";
                }
                else if (br == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    change = false;
                    this.Text = "Notepad";
                }
            }
            else
            {
                richTextBox1.Text = "";
                change = false;
                this.Text = "Notepad";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            change = true;
            this.Text = "Notepad*";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (change == true)
            {
                DialogResult br = MessageBox.Show("Do you want save your Result?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (br == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    richTextBox1.Text = "";
                    change = false;
                    this.Text = "Notepad";
                }
                else if (br == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    change = false;
                    this.Text = "Notepad";
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.Checked = !aboutToolStripMenuItem.Checked;
            statusStrip1.Visible = aboutToolStripMenuItem.Checked;
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bing.com/search?q=get+help+with+notepad+in+windows+10&filters=guid:%224466414-en-dia%22%20lang:%22en%22&form=T00032&ocid=HelpPane-BingIA");
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = DateTime.Now.ToString();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void selectALLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}

