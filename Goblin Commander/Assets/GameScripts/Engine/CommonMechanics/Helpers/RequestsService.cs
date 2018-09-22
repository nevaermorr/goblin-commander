public static class RequestsService
{
    public static GameEntity CreateRequestEntity()
    {
		GameEntity requestEntity = Contexts.sharedInstance.game.CreateEntity();
        requestEntity.isRequest = true;
        return requestEntity;
    }
}