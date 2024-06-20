/* 
 * CC.cs: 
 * Formats and presents information via the console.
 * 
 *  2024.02.21, Tom.McNamee@uagc.edu : added tabs support, upgraded to .NET 6.0
 *  2021.11.30, Tom.McNamee@uagc.edu : added Header support
 *  2016.04.01, Tom.McNamee@uagc.edu : initial coding (copied from Rml.ConsoleFormatting)
 */
using System.Runtime.InteropServices;

namespace Rml.CoNexus.ReverseProfile;

internal static class CC
{
    private const int SPACES_PER_TAB = 4;

    public enum ShowAs
    {
        HEADER,
        TEXT,
        INVERSE,
        TEXTALT1,
        TEXTALT2,
        TEXTALT3,
        EMPHASIS,
        PURPLE,
        CYAN,
        BLUE,
        YELLOW,
        PASS,
        FAIL,
        ERROR
    };

    private static readonly Dictionary<ShowAs, ConsoleColor[]> _bgfg = new()
    {
        {ShowAs.HEADER, new[] {ConsoleColor.DarkBlue, ConsoleColor.Yellow} },
        {ShowAs.TEXT, new[] { ConsoleColor.Black, ConsoleColor.Gray} },
        {ShowAs.INVERSE,  new[] { ConsoleColor.White, ConsoleColor.Black} },
        {ShowAs.TEXTALT1, new[] { ConsoleColor.Black, ConsoleColor.Yellow} },
        {ShowAs.TEXTALT2, new[] { ConsoleColor.Black, ConsoleColor.Cyan} },
        {ShowAs.TEXTALT3, new[] { ConsoleColor.Black, ConsoleColor.Magenta} },
        {ShowAs.EMPHASIS, new[] { ConsoleColor.Black, ConsoleColor.White} },
        {ShowAs.PURPLE, new[] {ConsoleColor.Black, ConsoleColor.Magenta} },
        {ShowAs.CYAN, new[] {ConsoleColor.Black, ConsoleColor.Cyan} },
        {ShowAs.BLUE, new[] {ConsoleColor.Black, ConsoleColor.Blue} },
        {ShowAs.YELLOW, new[] {ConsoleColor.Black, ConsoleColor.Yellow} },
        {ShowAs.PASS, new[] {ConsoleColor.Black, ConsoleColor.Green} },
        {ShowAs.FAIL, new[] {ConsoleColor.Black, ConsoleColor.Red} },
        {ShowAs.ERROR, new[] { ConsoleColor.DarkRed, ConsoleColor.White} }
    };

    public static void Header(string msg, string? version = null)
    {
        Stripe();
        Center(msg);
        if (version is not null) Center(version);
        Stripe();
        Crlf();
    }

    public static void Demo()
    {
        Crlf();
        Left("Available color schemes:");
        foreach (ShowAs key in _bgfg.Keys)
        {
            Left(1, key.ToString(), key);
        }
        Crlf();
    }

    public static void Stripe(char c = '%', ShowAs colorSet = ShowAs.HEADER) =>
        show(new string(c, Console.WindowWidth),
             true,
             colorSet);

    public static void Center(string msg, ShowAs colorSet = ShowAs.HEADER)
    {
        int sideLength = Console.WindowWidth - msg.Length;
        if (sideLength < 0)
        {
            Write(msg, colorSet);
            return;
        }
        string sideBuffer = new(' ', sideLength / 2);
        WriteLine($"{sideBuffer}{msg}{sideBuffer}", colorSet);
    }
    public static void Left(int tabs, string msg, ShowAs colorSet = ShowAs.TEXT) =>
        show(tabs,
             $"{msg}{new string(' ', Console.WindowWidth - msg.Length)}",
             true,
             colorSet);

    public static void Left(string msg, ShowAs colorSet = ShowAs.TEXT) =>
        show($"{msg}{new string(' ', Console.WindowWidth - msg.Length)}",
             true,
             colorSet);

    public static void Right(string msg, ShowAs colorSet = ShowAs.TEXT) =>
        show($"{new string(' ', Console.WindowWidth - msg.Length)}{msg}",
             true,
             colorSet);

    public static void Crlf() => show("", true, ShowAs.TEXT);

    public static void WriteLine(int tabs, string msg, ShowAs colorSet = ShowAs.TEXT) =>
        show(string.Concat(new string(' ', tabs * SPACES_PER_TAB), msg),
             true,
             colorSet);

    public static void WriteLine(string msg, ShowAs colorSet = ShowAs.TEXT) => show(msg, true, colorSet);

    public static void Write(int tabs, string msg, ShowAs colorSet = ShowAs.TEXT) =>
        show(string.Concat(new string(' ', tabs * SPACES_PER_TAB), msg),
             false,
             colorSet);

    public static void Write(string msg, ShowAs colorSet = ShowAs.TEXT) => show(msg, false, colorSet);

    private static void show(int tabs, string msg, bool crlf, ShowAs colorSet)
    {
        int indent = tabs * SPACES_PER_TAB;

        string tabbedMsg = string.Concat(new string(' ', indent), msg[..^indent]);
        show(tabbedMsg, crlf, colorSet);
    }

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
    private static readonly IntPtr ThisConsole = GetConsoleWindow();

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
