using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ProductProtection
{
    public partial class ProductProtection : Form
    {
        private string sectretFormThatContainsCodes = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\" + "AuthorsInfo.txt");

        //looks after the Trial Time
        protected DateTime Begins;
        protected DateTime CurrentDate;
        protected DateTime Expires;
        protected int timeLeft;
        protected string amountOfTrialsLimit = "1";
        protected string amountOfTrials = "2";

        public ProductProtection()
        {
            InitializeComponent();
            findValueCount();
            if (amountOfTrials.CompareTo("0") == 0)
            {
                writetimeLeft();
            }
            mainMethod();
            checkDate();
            
        }

        private void checkDate() {
            if (Begins > CurrentDate || CurrentDate > Expires) { timeLeft = 0; }	//CD is date the computer has
            if(Begins<CurrentDate && CurrentDate<Expires){
                Begins = CurrentDate;
                labelDaysRemain.Text = daysRemain();
            }
            else
            {
                labelDaysRemain.Text = "0";
                buttonContinue.Enabled = false;
            }
        }
        private string daysRemain()
        {
            TimeSpan current = Expires.Subtract(DateTime.Now);
            string[] temp = Convert.ToString(current).Split('.');
            timeLeft = Convert.ToInt32(temp[0]);
            return temp[0];
        }
#region textBoxes
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Select(textBox1.Text.Length, 0); //This line sets the cursor along the text at the end
            textBox1.Text = only4Values(textBox1.Text);
            if (countValues(textBox1.Text).CompareTo(4) >= 0)
            {
                textBox2.Focus();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = only4Values(textBox2.Text);
            if (countValues(textBox2.Text).CompareTo(4) == 0)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = only4Values(textBox3.Text);
            if (countValues(textBox3.Text).CompareTo(4) == 0)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = only4Values(textBox4.Text);
            if (countValues(textBox4.Text).CompareTo(4) == 0)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = only4Values(textBox5.Text);
            if (countValues(textBox5.Text).CompareTo(4) == 0)
            {
                buttonAccept.Visible = true;
            }
        }
        private int countValues(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                count++;
            }
            return count;
        }
        private string only4Values(string text)
        {
            int count = 0;
            string keep = "";
            foreach (char c in text)
            {
                if (count.CompareTo(3) <= 0)
                {
                    keep += c;
                    count++;
                }
            }
            return keep;
        }
#endregion
        private void mainMethod(){
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(sectretFormThatContainsCodes))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("john"))
                        {
                            string[] temp = line.Split('|');

                            Begins = Convert.ToDateTime(temp[3]).Subtract(TimeSpan.FromSeconds(1)) ;
                            CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("d"));
                            Expires = Convert.ToDateTime(temp[4]);
                            amountOfTrials = temp[5];
                            //MessageBox.Show(" Beg: " + Begins + " Curr: " + CurrentDate + " Exp: " + Expires +" AOT: "+amountOfTrials);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        private void findValueCount()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(sectretFormThatContainsCodes))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("john"))
                        {
                            string[] temp = line.Split('|');
                            amountOfTrials = temp[5];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            
             //check that the code is correct
            string inputtext = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text;
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(sectretFormThatContainsCodes))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("kerry"))
                        {
                            string[] temp = line.Split('|');
                            string thisVal = temp[1].Replace("-","");
                            if (thisVal.CompareTo(inputtext) == 0) {
                                amountOfTrials = "2";
                                MessageBox.Show("Accepted");
                            }
                        }
                        //textBoxInfo.AppendText(line);
                        //line.Contains("Introduction")
                        //                            string[] temp = line.Split('#');
                        //    textBoxInfo.Text = temp[0].TrimEnd('.');
                        //    textBoxInfo.Text = textBoxInfo.Text + "\r\n\r\n";
                    }
                }
            }
            catch (Exception r)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(r.Message);
            }
        }

        public event EventHandler continueButtonClicked;

        public void continueNotifyButtonClicked(EventArgs e)
        {
            if (continueButtonClicked != null)
                continueButtonClicked(this, e);

        }

        private void buttonContinue_Click_1(object sender, EventArgs e)
        {
            continueNotifyButtonClicked(e);
        }

        private void buttonAccept_Click_1(object sender, EventArgs e)
        {
            amountOfTrialsLimit = "2";
            writetimeLeft();
            if (amountOfTrials.CompareTo("2") != 0)
            {
                labelDaysRemain.Text = "30";
                buttonContinue.Enabled = true;
                buttonAccept.Visible = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else { MessageBox.Show("Error: Key has already been used"); }
        }

        private void writetimeLeft()
        {
            try
            {
                ArrayList temp = new ArrayList(100);

                ///reads the file 
                ///adds it to the array
                ///
                using (StreamReader sr = new StreamReader(sectretFormThatContainsCodes))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        temp.Insert(i, line);
                        i++;
                    }
                }

                using (StreamWriter outputStream = new StreamWriter(sectretFormThatContainsCodes))
                {
                    for (int g = 0; g < temp.Count; g++)
                    {

                        if (Convert.ToString(temp[g]).Contains("john"))
                        {
                            //get the string out
                            string[] getOutDates = Convert.ToString(temp[g]).Split('|');

                            //its 3,4,5 cause its in the same paragraph as the key so there are heaps of '|' spacers
                            //you want a second 30 days
                            if (getOutDates[5].CompareTo(amountOfTrialsLimit) != 0)
                            {
                                //write in the updated time
                                getOutDates[3] = Convert.ToString(DateTime.Now.ToString("d"));
                                getOutDates[4] = Convert.ToString(DateTime.Now.AddDays(31).ToString("d"));
                                getOutDates[5] = Convert.ToString(Convert.ToInt32(getOutDates[5]) + 1);
                                //write the line back in
                                outputStream.WriteLine(getOutDates[0] + "|" + getOutDates[1] + "|" + getOutDates[2] + "|" + getOutDates[3] + "|" + getOutDates[4] + "|" + getOutDates[5] + "|" + getOutDates[6]);
                            }
                        }
                        else
                        {
                            outputStream.WriteLine(temp[g]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }
    }
}
