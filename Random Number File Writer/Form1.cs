//Sabrina Turney
//C# I
//Assignment Chapter 5.13 - Rnadom Number File Writer


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Including System to use Save option and Write options
using System.IO;

namespace Random_Number_File_Writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            try //starting off with a try block for writing and saving full input
            {
                //Using Streamwriter to get an easier variable to use first off!
                StreamWriter savedFile;
                int amt = int.Parse(inputTextBox.Text.ToString());
                //taking the string entered by the user, using parsing to change it to a usable calculaiton
                //this allows us to iterate.
                int randNum = 0;
                int iteration = 1;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    savedFile = File.CreateText(saveFileDialog1.FileName);
                    Random rand = new Random();

                    while (iteration <= amt) 
                        //This while block does the work, iterating through each number entered by the user
                        //Then writing a random number to the numbers the user gave into a new file.
                    {
                        randNum = rand.Next(100) + 1;
                        savedFile.WriteLine(randNum);
                        iteration++;
                    }
                    //IMPORTANT: Close a file once you're done with it. 
                    savedFile.Close();
                }//catches if the file does not save correctly to the savedialogbox in form designer.
                else
                {
                    MessageBox.Show("Error: Your file could not save.");
                }
            }//actual catch block to catch anything except the requested integers:
            catch
            {
                MessageBox.Show("Please enter a whole integer between 1 and 100.");
            }
        }
        //Closing the program, my personal favorite part. Hard to mess this event up.
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
