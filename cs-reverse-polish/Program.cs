using System;
using System.ComponentModel;

delegate int Operator(Stack<int> s);

class Program
{

    public static Dictionary<string, Operator> Operators = new Dictionary<string, Operator>()
    {
        {"+", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return left + right;
        })},
        {"-", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return left - right;
        })},
        {"*", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return left * right;
        })},
        {"/", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return left / right;
        })},
        {"%", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return left % right;
        })},
        {"**", new Operator((Stack<int> s) =>
        {
        var right = s.Pop();
        var left = s.Pop();
        return (int)Math.Pow(left, right);
        })},
        {
            "neg", new Operator((Stack<int> s) => 
            -1 * s.Pop())
        }
    };

    public static void Main(string[] args)
    {

        var s = new Stack<int>();
        string[] input = (string.Empty + Console.ReadLine()).Split(' ');
        foreach(string e in input)
        {
            if (Operators.ContainsKey(e))
            {
                s.Push(Operators[e](s));
            }
            else
            {
                s.Push(Convert.ToInt32(e));
            }
        }
        Console.WriteLine(s.Peek().ToString());
    }
}
