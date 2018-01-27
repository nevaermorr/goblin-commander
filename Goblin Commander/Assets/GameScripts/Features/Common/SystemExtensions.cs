using System;

public static class SystemExtensions
{
    public static void InvokeIfNotNull(this Action action)
    {
        if (action != null)
        {
            action.Invoke();
        }
    }
}