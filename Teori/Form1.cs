using Microsoft.EntityFrameworkCore;
using Teori.Data;
using Teori.Model;

namespace Teori
{
    public partial class Form1 : Form
    {
        QnAContext context = new QnAContext();
        public Form1()
        {
            InitializeComponent();
            LoadQuestionNumbers();
        }


        public void LoadQuestionNumbers()
        {

            var questionIds = context.QnAs.Select(q => q.Id).ToList();
            comboBox1.DataSource = questionIds;

        }




        private void button1_Click(object sender, EventArgs e)
        {

            // Get the selected question ID from the ComboBox
            if (comboBox1.SelectedItem is int selectedQuestionId)
            {
                // Check if a question with the selected ID exists
                var questionExists = context.QnAs.FirstOrDefault(q => q.Id == selectedQuestionId);

                if (questionExists != null)
                {
                    // Retrieve and display the question text in the label
                    var questionText = context.QnAs.Where(q => q.Id == selectedQuestionId).Select(q => q.Question).FirstOrDefault();
                    label2.Text = questionText;
                }
                else
                {
                    MessageBox.Show("Selected question not found.");
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is int selectedQuestionId)
            {
                var answerExistes = context.QnAs.FirstOrDefault(q => q.Id == selectedQuestionId);

                if (answerExistes != null)
                {
                    var answerText = context.QnAs.Where(q => q.Id == selectedQuestionId).Select(q => q.Answer).FirstOrDefault();
                    label3.Text = answerText;
                }
                else
                {
                    MessageBox.Show("Selected answer not found.");
                }
            }
        }
    }
}

