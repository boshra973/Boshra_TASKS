using EF1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing.Text;
using System.Reflection;

namespace EF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null)
            {
                MessageBox.Show("Select a Student to update.");
                return;
            }
            //    cast the id to int       the selected row -- cells : get the cell that belowong to id
            int id = (int)dataGridView1.CurrentRow.Cells["StudentId"].Value;

            using (var context = new UniversityContext())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentId == id);
                if (student != null)
                {
                    student.SfirstName = fNametxt.Text.Trim();
                    student.SlastName = lnametxt.Text.Trim();
                    student.Adress = adresstxt.Text.Trim();
                    if (DateOnly.TryParse(birthdatetxt.Text.Trim(), out DateOnly date))
                    {
                        student.BirthDate = date;
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid date (0000-00-00).");
                        return;
                    }
                    context.SaveChanges();
                    MessageBox.Show("Student Updated Successfully =)).");

                    displayData();

                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            // student.StudentId = int.Parse(Idtxt.Text.Trim());
            student.SfirstName = fNametxt.Text.Trim();
            student.SlastName = lnametxt.Text.Trim();
            student.Adress = adresstxt.Text.Trim();
            if (DateOnly.TryParse(birthdatetxt.Text.Trim(), out DateOnly date))
            {
                // try pars return true if the date is valid: 0000-00-00;
                // out gives the converted value if it's true 
                // when it is true it wil l be stored in the variable date 
                student.BirthDate = date;
            }
            else
            {
                MessageBox.Show("Please enter a valid date (0000-00-00)");
            }


            using (UniversityContext context = new UniversityContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
            MessageBox.Show("Student submitted Successfully =)");
            displayData();
        }
        private void displayData()
        {
            using (var context = new UniversityContext())
            {
                var data = context.Students.Select(s => new
                {
                    s.StudentId,
                    s.SfirstName,
                    s.SlastName,
                    s.Adress,
                    s.BirthDate
                }).ToList();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = data;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            displayData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a Student to update.");
                return;
            }
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StudentId"].Value);
            // confirming delete: 
            DialogResult result = MessageBox.Show("Are you want to delet this Student? This will also delete all their Enrollments",
                                                   "Confirm Delete", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var context = new UniversityContext())
                {
                    // we must delete enrollments first: (foreign keys)
                    // make sure at first they are loaded 
                    
                    var student = context.Students.Include (s => s.Enrollments).FirstOrDefault(s => s.StudentId == id);
                    if (student != null) // check if this sudent has enrolled courses aslan
                    {
                        if (student.Enrollments != null && student.Enrollments.Any())// .any : atleast one course
                        {
                            context.Enrollments.RemoveRange(student.Enrollments);
                        }
                        context.Students.Remove(student);
                        context.SaveChanges();

                        MessageBox.Show("Student Deleted successfully");

                        displayData();
                    }
                    else
                    {
                        MessageBox.Show("Student not found.");
                    }
                }
            }
        }
    }
}

