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
using System.Text.RegularExpressions;

namespace FrmLab1
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            btnRegister.Click += btnRegister_Click;
        }

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {
            try
            {
                if (string.IsNullOrEmpty(studNum))
                {
                    throw new ArgumentException("Student No. must be filled up!");
                }
                else
                {
                    _StudentNo = long.Parse(studNum);
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.WriteLine("Input 11 index only ");
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new ArgumentNullException("Lastname, Firstname or Middleinitial textbox is empty");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.WriteLine("Do not leave the Lastname, Firstname and Middleinitials textbox empty");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new OverflowException("Invalid Input");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.WriteLine("Finally blocked executed");
            }

            return _Age;
        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListofProgram = new string[]
                {
                    "BS Information Technology",
                    "BS Computer Science",
                    "BS Information Systems",
                    "BS in Accountancy",
                    "BS in Hospitality Management",
                    "BS in Tourism Management"
                };

            try
            {
                if (ListofProgram.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        cbProgram.Items.Add(ListofProgram[i].ToString());
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException cs)
            {
                MessageBox.Show(cs.Message);
            }

            string[] ListofGender = new string[]
                {
                    "Male",
                    "Female"
                };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListofGender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string[] stud_info = {"Student No : " + txtStudentNo.Text, "Full Name : " + txtLastname.Text
                    + " " + txtFirstname.Text + " " + txtMI.Text + " ", "Program : " + cbProgram.Text,
                    "Gender " + cbGender.Text, "Age : " + txtAge.Text, "Birthday : " + dtpBirthday.Value.ToShortDateString(),
                    "Contact No : " + txtContactNo.Text};
            string doccPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(doccPath, txtStudentNo.Text + ".txt")))
            {
                foreach (string cs in stud_info)
                {
                    outputFile.WriteLine(cs);
                }

                MessageBox.Show("Successfuly Created");
                Close();
            }
        }
    }
}
