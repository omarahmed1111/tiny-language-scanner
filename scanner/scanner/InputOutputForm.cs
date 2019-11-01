using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace scanner
{
    public partial class InputOutputForm : Form
    {
        int out_no;
        scanner1 sc;
        StreamWriter writer;
        public InputOutputForm()
        {
            InitializeComponent();
            out_no = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            try
            {
                string output = "output" + out_no.ToString() + ".txt";
                writer = new StreamWriter(output);
                sc = new scanner1(f, writer);
                int done = sc.scan();
                writer.Close();
                if (done == 0)
                {
                    List<string> tokns = new List<string>();
                    List<string> values = new List<string>();
                    int counter_of_tokens = 0;
                    string file_text = File.ReadAllText(output);
                    for (int i = 0; i < file_text.Length; i++)
                    {
                        if (i == file_text.Length - 1)
                            break;
                        char cur = file_text[i];
                        string name1 = "";
                        while (cur != ',') {
                            if(cur != ' ' && cur != '\n' && cur != '\t' && cur != '\r')
                                name1 += cur;
                            i++;
                            cur = file_text[i];
                        }
                        i++;
                        cur = file_text[i];
                        i++;
                        cur = file_text[i];
                        string name2 = "";
                        while (cur != ' ' && cur != '\n' && cur != '\t' && cur != '\r')
                        {
                            if (cur != ' ' && cur != '\n' && cur != '\t' && cur != '\r')
                                name2 += cur;
                            i++;
                            cur = file_text[i];
                        }
                        tokns.Add(name1);
                        values.Add(name2);
                        counter_of_tokens++;

                    }
                    Output form = new Output(tokns,values,counter_of_tokens);
                    form.Show();
                    Hide();
                }
                else
                {
                    label2.Text = "syntax error";
                    label2.ForeColor = Color.Red;
                }
            }
            catch
            {
                writer.Close();
            }
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            SelectMode form = new SelectMode();
            form.Show();
            Hide();
        }
    }
}
