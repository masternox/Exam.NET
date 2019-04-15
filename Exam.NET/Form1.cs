using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam.NET
{
    public partial class Form1 : Form
    {
        private Exam exam;
        private ToolStripLabel status;

        public Form1()
        {
            InitializeComponent();
            groupBox1.Hide();
            groupBox1.Enabled = false;
            status = new ToolStripLabel("");
            toolStrip1.Items.Add(status);
        }

        private void presentQuestion()
        {
            Question current = exam.getNextQuestion();
            if (current == null)
            {
                // End of exam
                if (exam.nbQuestions() == 0)
                    label1.Text = "The exam failed loading!\nPlease make sure your file has a valid exam structure.";
                else
                    label1.Text = "The exam is finished, thank you for participating!\nYou can now close this window.";
                checkBox1.Hide();
                checkBox2.Hide();
                checkBox3.Hide();
                checkBox4.Hide();
                button1.Hide();
                status.Text = "";
                return;
            }
            checkBox1.Show();
            checkBox2.Show();
            checkBox3.Show();
            checkBox4.Show();
            button1.Show();
            status.Text = exam.nbCurrent().ToString() + "/" + exam.nbQuestions().ToString();
            label1.Text = current.get();
            Random random = new Random();
            List<String> answers = current.getAnswers().OrderBy(c => random.Next()).ToList();
            
            if (answers.Count == 4)
            {
                checkBox1.Text = answers[0];
                checkBox2.Text = answers[1];
                checkBox3.Text = answers[2];
                checkBox4.Text = answers[3];
            }
            else if (answers.Count > 2)
            {
                checkBox1.Text = answers[0];
                checkBox2.Text = answers[1];
                checkBox3.Text = answers[2];
                checkBox4.Hide();
            }
            else if (answers.Count > 1)
            {
                checkBox1.Text = answers[0];
                checkBox2.Text = answers[1];
                checkBox3.Hide();
                checkBox4.Hide();
            }
            else
            {
                checkBox1.Hide();
                checkBox2.Hide();
                checkBox3.Hide();
                checkBox4.Hide();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate answer result
            presentQuestion();
        }

        private void takeAPracticeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exam = new Exam();
            exam.test();
            groupBox1.Text = exam.getName();
            presentQuestion();
            groupBox1.Show();
            groupBox1.Enabled = true;
        }

        private void loadAnExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exam = new Exam();
            exam.loadfromFile();
            groupBox1.Text = exam.getName();
            presentQuestion();
            groupBox1.Show();
            groupBox1.Enabled = true;
        }

        private void closeExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox1.Enabled = false;
            status.Text = "";
        }
    }
}
