using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems systems;
    private Contexts contexts;

    private void Start()
    {
        contexts = Contexts.sharedInstance;
        systems = CreateFeatures(contexts);
        systems.Initialize();
    }

    private void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }

    private Systems CreateFeatures(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new EngineFeature(contexts))
            .Add(new GeneratorFeature(contexts))
            .Add(new IngameMechacnicsFeature(contexts))
        ;
    }
}