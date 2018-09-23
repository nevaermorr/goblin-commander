using UnityEngine;

public class HealthbarBehaviour : BarBehaviour, ICurrentHealthListener
{

    protected override Color[] GetCellColorGradient()
    {
        Color[] cellColorGradient = {
            Color.red,
            Color.yellow,
            Color.green
        };
        return cellColorGradient;
    }

    protected override GameEntity AttachListenerComponent(GameEntity listenerEntity)
    {
        listenerEntity.AddCurrentHealthListener(this);
        return listenerEntity;
    }

    public void OnCurrentHealth(GameEntity entity, float currentHealth)
    {
        OnParameterChanged(entity, currentHealth);
    }


    protected override float GetParameterMaxValue(GameEntity entity)
    {
        return entity.maxHealth;
    }
}
