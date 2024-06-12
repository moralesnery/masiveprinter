using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace MasivePrinter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            GetPrinters();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e) {
            //lista de path de los archivos arrastrados
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //Agregar a la lista del listview
            string ignoredtext = "Los siguientes archivos fueron ignorados porque no son PDFs:\r\n\r\n";
            bool ignoredfiles = false;

            foreach (string file in files) {
                if (file.ToLower().Contains(".pdf")) {
                    listView1.Items.Add(file);
 
                } else {
                    ignoredfiles = true;
                    ignoredtext += "× " + file.Split('\\')[file.Split('\\').Count() - 1] + "\r\n";
                }
            }

            if (ignoredfiles) {
                MessageBox.Show(ignoredtext);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            listView1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex >= 0) {

                //Imprimir
                foreach (ListViewItem ruta in listView1.Items) {
                    string comando = AppDomain.CurrentDomain.BaseDirectory + "sumatra.exe \"" + ruta.Text + "\" -print-to \"" + comboBox1.SelectedItem.ToString() + "\" -silent -exit-when-done";
                    Console.WriteLine(comando + "\r\n");

                    var proc1 = new ProcessStartInfo();
                    string anyCommand;
                    proc1.UseShellExecute = true;
                    //proc1.WorkingDirectory = @"C:\Windows\System32";

                    proc1.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\sumatra.exe";
                    //proc1.Verb = "runas";
                    proc1.Arguments = " \"" + ruta.Text + "\" -print-to \"" + comboBox1.SelectedItem.ToString() + "\" -silent -exit-when-done";
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(proc1);
                }

            } else {
                MessageBox.Show("Selecciona una impresora");
            }
            
            
        }

        private void GetPrinters() {
            comboBox1.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters) {
                comboBox1.Items.Add(printer);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            MessageBox.Show("♥︎");
        }
    }
}
