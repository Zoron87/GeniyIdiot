using System;
using System.ComponentModel.DataAnnotations;

namespace GeniyIdiot.Common
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public double PercentCorrectAnswers { get; set; }

        public string Diagnose { get; set; }

        public User()
        {

        }

        public User(string name, double percentCorrectAnswers, string Diagnose)
        {
            this.Name = name;
            this.PercentCorrectAnswers = percentCorrectAnswers;
            this.Diagnose = Diagnose;
        }
    }
}