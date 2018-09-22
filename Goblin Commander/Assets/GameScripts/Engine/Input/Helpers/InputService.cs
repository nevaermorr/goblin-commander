public static class InputService
{
    public static void IgnoreInputForCurrentFrame()
    {
        Contexts.sharedInstance.input.inputStateEntity.isIgnoreInput = true;
    }
    public static void UnignoreInputForCurrentFrame()
    {
        Contexts.sharedInstance.input.inputStateEntity.isIgnoreInput = false;
    }
}