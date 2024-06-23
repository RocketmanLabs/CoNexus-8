using System.Runtime.InteropServices;

namespace Rml.CoNexus.Sandbox;

internal static class CC
{
    public enum ShowAs
    {
        HEADER,
        TEXT,
        INVERSE,
        PROMPT1,
        PROMPT2,
        PASS,
        FAIL,
        ERROR,
        YELLOW,
        RED,
        GREEN,
        CYAN,
        MAGENTA
    };

    static Dictionary<ShowAs, ConsoleColor[]> _bgfg = new() {
        {ShowAs.HEADER, [ConsoleColor.DarkBlue, ConsoleColor.Yellow] },
        {ShowAs.TEXT, [ConsoleColor.Black, ConsoleColor.White] },
        {ShowAs.INVERSE,  [ConsoleColor.White, ConsoleColor.Black] },
        {ShowAs.PROMPT1, [ConsoleColor.DarkGreen, ConsoleColor.Yellow] },
        {ShowAs.PROMPT2, [ConsoleColor.DarkRed, ConsoleColor.Yellow] },
        {ShowAs.PASS, [ConsoleColor.Black, ConsoleColor.Green] },
        {ShowAs.FAIL, [ConsoleColor.Black, ConsoleColor.Red] },
        {ShowAs.ERROR, [ConsoleColor.DarkRed, ConsoleColor.White] },
        {ShowAs.YELLOW, [ConsoleColor.Black, ConsoleColor.Yellow] },
        {ShowAs.RED, [ConsoleColor.Black, ConsoleColor.Red] },
        {ShowAs.GREEN, [ConsoleColor.Black, ConsoleColor.Green] },
        {ShowAs.CYAN, [ConsoleColor.Black, ConsoleColor.Cyan] },
        {ShowAs.MAGENTA, [ConsoleColor.Black, ConsoleColor.Magenta] }
    };

    public static void Header(string title, string version)
    {
        Stripe();
        Center(title);
        Center(version);
        Stripe();
        Crlf();
    }

    public static void Stripe(char c = '%', ShowAs colorSet = ShowAs.HEADER) => WriteLine(new string(c, Console.WindowWidth), colorSet);

    public static void Center(string msg, ShowAs colorSet = ShowAs.HEADER)
    {
        int sideLength = Console.WindowWidth - msg.Length;
        if (sideLength < 0)
        {
            Write(msg, colorSet);
            return;
        }
        string sideBuffer = new string(' ', sideLength / 2);
        WriteLine($"{sideBuffer}{msg}{sideBuffer}", colorSet);
    }

    public static void Right(string msg, ShowAs colorSet = ShowAs.TEXT) => WriteLine($"{new string(' ', Console.WindowWidth - msg.Length)}{msg}", colorSet);

    public static void Left(string msg, ShowAs colorSet = ShowAs.TEXT) => WriteLine($"{msg}{new string(' ', Console.WindowWidth - msg.Length)}", colorSet);

    public static void Crlf() => show("", true, ShowAs.TEXT);

    public static void WriteLine(string msg, ShowAs colorSet = ShowAs.TEXT) => show(msg, true, colorSet);

    public static void Write(string msg, ShowAs colorSet = ShowAs.TEXT) => show(msg, false, colorSet);

    private static void show(string msg, bool crlf, ShowAs colorSet)
    {
        Console.BackgroundColor = _bgfg[colorSet][0];
        Console.ForegroundColor = _bgfg[colorSet][1];
        if (crlf)
        {
            Console.WriteLine(msg);
        }
        else
        {
            Console.Write(msg);
        }
        Console.ResetColor();
    }

    #region Window control

    public static void MaximizeConsole() => _ = WindowControl(Operation.Maximize);

    [DllImport("kernel32.dll", ExactSpelling = true)]

    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public enum Operation
    {
        Hide = 0,
        Maximize = 3,
        Minimize = 6,
        Restore = 9
    };

    public static bool WindowControl(Operation op) => ShowWindow(ThisConsole, (int)op);
    #endregion
}
