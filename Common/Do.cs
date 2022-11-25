using System.Diagnostics.CodeAnalysis;

namespace Dnsk.Common;

public static class Do
{
    public static void If(bool condition, Action fn)
    {
        if (condition)
        {
            fn();
        }
    }
    
    public static async Task IfAsync(bool condition, Func<Task> fn)
    {
        if (condition)
        {
            await fn();
        }
    }
}

public static class Throw
{
    public static void If<T>(bool condition, T ex) where T : Exception
    {
        Do.If(condition, () => throw ex);
    }
}