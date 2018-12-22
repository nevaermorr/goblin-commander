using System.Collections.Generic;
using Entitas;

public class EnergyRequestsSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public EnergyRequestsSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnergyRequireingRequest);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity requestEntity in entities)
        {
            ProcessRequest(requestEntity.energyRequireingRequest);
        }
    }

    private void ProcessRequest(EnergyRequireingRequestComponent request)
    {
        if (HasEnoughEnergy(request.EnergyCost))
        {
            PayRequestCost(request.EnergyCost);
            PerformRequest(request);
        }
        else
        {
            RejectRequest(request);
        }
    }

    private bool HasEnoughEnergy(float energyCost)
    {
        return gameContext.gameStateEntity.currentEnergy >= energyCost;
    }

    private void PayRequestCost(float requestCost)
    {
        gameContext.gameStateEntity.ReplaceCurrentEnergy(
            gameContext.gameStateEntity.currentEnergy - requestCost
        );
    }

    private void PerformRequest(EnergyRequireingRequestComponent request)
    {
        request.OnSuccess.InvokeIfNotNull();
    }
    
    private void RejectRequest(EnergyRequireingRequestComponent request)
    {
        request.OnFailure.InvokeIfNotNull();
    }
}