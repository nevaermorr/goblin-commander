using UnityEngine;
using Entitas;

[Game]
public class CooldownComponent : IComponent
{
    public float TimeLeft;

    public void ReportTimePassed(float timePassed)
    {
        if (TimeLeft > 0f) {
            TimeLeft -= timePassed;
        }
    }

    public bool IsReady()
    {
        return TimeLeft <= 0f;
    }
}
