using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.NET
{
    class Question
    {
        private string question;
        private List<string> answers;
        private string freeanswer;
        //private bool checkboxes;

        public Question(string q)
        {
            question = q;
        }

        public Question(string q, string a1, string a2)
        {
            question = q;
            answers = new List<string>();
            answers.Add(a1);
            answers.Add(a2);
        }

        public Question(string q, string a1, string a2, string a3)
        {
            question = q;
            answers = new List<string>();
            answers.Add(a1);
            answers.Add(a2);
            answers.Add(a3);
        }

        public Question(string q, string a1, string a2, string a3, string a4)
        {
            question = q;
            answers = new List<string>();
            answers.Add(a1);
            answers.Add(a2);
            answers.Add(a3);
            answers.Add(a4);
        }

        public void setFreeAnswer(string answer)
        {
            freeanswer = answer;
        }

        public string get()
        {
            return question;
        }

        public List<string> getAnswers()
        {
            return answers;
        }
    }
}
