using Newtonsoft.Json;
using System;

public class Question
{
    public string Text;
    public int Answer;

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