using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;

[RequireComponent (typeof (ParticleSystem))]
public class DamageEffectBehaviour : MonoBehaviour, IDamageListener
{
    [SerializeField]
    private GameObject owner;
    private ParticleSystem bloodParticles;

    private GameEntity damageListener;
    private float cellGradientHealthPercentage;

    private void Awake()
    {
        bloodParticles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        Bind();
    }
    private void OnDisable()
    {
        Unbind();
    }

    private void Bind()
    {
        damageListener = Contexts.sharedInstance.game.CreateEntity();
        damageListener.AddDamageListener(this);
    }

    private void Unbind()
    {
        damageListener.Destroy();
    }

    public void OnDamage(GameEntity entity, float damage, GameEntity origin, GameEntity target)
    {
        if (target != owner.GetEntityLink().entity)
        {
            return;
        }
        
        bloodParticles.Play();
    }
}
