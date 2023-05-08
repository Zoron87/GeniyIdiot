using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

public class Question
{
    [Key]
    public int id { get; set; }
    public string Text { get; set; }
    public int Answer { get; set; }
    public Question() { }

    public Question(string text, int answer)
    {
        Text = text;    
        Answer = answer;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}