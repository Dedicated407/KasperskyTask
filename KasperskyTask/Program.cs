using System.Text.RegularExpressions;

namespace KasperskyTask;

public class Program
{
    private const string MainFolder = "MainFolder";
    private const string Pattern = "[a-z]+[0-9]+\\/";

    static void Main(string[] args)
    {
        var ops = new List<string> {"d1/", "d2/", "../", "d21/", "./"};
        var ops1 = new List<string> {"./", "../", "../", "d21/", "./", "d33/", "../", "../"};
        Console.WriteLine(FindMinimumPathToMainFolder(ops1));
    }

    private static int FindMinimumPathToMainFolder(List<string> ops)
    {
        var stack = new Stack<string>();
        
        stack.Push(MainFolder);

        foreach (var op in ops)
        {
            if (Regex.IsMatch(op, Pattern))
            {
                stack.Push(op.Remove(op.Length - 1));
            }
            else if (op.Contains("../"))
            {
                var data = stack.Peek();
                if (data != MainFolder)
                {
                    stack.Pop();
                }
            }
        }

        return stack.Count - 1; // MainFolder не включительно
    }
}