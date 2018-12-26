using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EnergyRefillOverTimeSystem : IExecuteSystem
{
    GameContext gameContext;
    private float timeToRefill;

    public EnergyRefillOverTimeSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Execute()
    {
        if (IsEnergyAtMax())
        {
            ResetTimer();
            return;
        }

        UpdateTimeToRefill();
        if (timeToRefill <= 0f) {
            RefillEnergy();
            AddTimeToRefill();
        }
    }

    private void RefillEnergy()
    {
        gameContext.gameStateEntity.ReplaceCurrentEnergy(
            gameContext.gameStateEntity.currentEnergy
            + gameContext.settingsEntity.globalSettings.Value.EnergyRecoveryAmountOverTime
        );
    }

    private void ResetTimer()
    {
        timeToRefill = gameContext.settingsEntity.globalSettings.Value.EnergyRecoveryInterval;
    }

    private void AddTimeToRefill()
    {
        timeToRefill += gameContext.settingsEntity.globalSettings.Value.EnergyRecoveryInterval;
    }

    private void UpdateTimeToRefill()
    {
        timeToRefill -= Time.deltaTime;
    }

    private bool IsEnergyAtMax()
    {
        return gameContext.gameStateEntity.currentEnergy >= gameContext.gameStateEntity.maxEnergy;
    }
}