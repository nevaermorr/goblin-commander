using UnityEngine;

public class EnergyBarBehaviour : BarBehaviour, ICurrentEnergyListener
{

    protected override Color[] GetCellColorGradient()
    {
        Color[] cellColorGradient = {
            Color.white,
            Color.cyan,
            Color.blue
        };
        return cellColorGradient;
    }

    protected override GameEntity AttachListenerComponent(GameEntity listenerEntity)
    {
        listenerEntity.AddCurrentEnergyListener(this);
        return listenerEntity;
    }

    public void OnCurrentEnergy(GameEntity entity, float currentEnergy)
    {
        OnParameterChanged(entity, currentEnergy);
    }

    protected override float GetParameterMaxValue(GameEntity entity)
    {
        return entity.maxEnergy;
    }
}
