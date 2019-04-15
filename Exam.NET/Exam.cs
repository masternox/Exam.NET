using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam.NET
{
    class Exam
    {
        string name;
        //int score;
        int currentQuestion;
        List<Question> questions;
        
        public Exam()
        {
            questions = new List<Question>();
            currentQuestion = 0;
            //score = 0;
        }

        public int nbQuestions()
        {
            return questions.Count;
        }

        public int nbCurrent()
        {
            return currentQuestion;
        }

        public string getName()
        {
            return name;
        }

        public Question getNextQuestion()
        {
            if (currentQuestion >= questions.Count)
            {
                // End of exam
                return null;
            }
            Question next = questions[currentQuestion];
            currentQuestion += 1;
            return next;
        }

        public void loadfromFile()
        {
            // Load exam questions from a structured file
            Random random = new Random();
            questions = questions.OrderBy(c => random.Next()).ToList();
        }

        public void test()
        {
            name = "Test exam";
            questions.Add(new Question("Who is the president of the United States?", "Donald Trump", "Ronald Trump", "Ronald Reagan", "Donald McDonald's"));
            questions.Add(new Question("What is the current year?", "2018", "2019", "2020", "2021"));
            questions.Add(new Question("11*12=", "121", "123", "132", "142"));
            Random random = new Random();
            questions = questions.OrderBy(c => random.Next()).ToList();
        }
    }
}
