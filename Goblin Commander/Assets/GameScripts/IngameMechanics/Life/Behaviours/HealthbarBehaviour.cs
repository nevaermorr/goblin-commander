using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;

public class HealthbarBehaviour : MonoBehaviour, ICurrentHealthListener {

	private Color[] cellGradient = {
		Color.red,
		Color.yellow,
		Color.green
	};

	[SerializeField]
	private SpriteRenderer[] cells;
	[SerializeField]
	private GameObject owner;

	private GameEntity healthListener;
    private float cellGradientHealthPercentage;

    private void Awake()
    {
        cellGradientHealthPercentage = (float)1 / (cells.Length * cellGradient.Length - 1);
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
		healthListener = Contexts.sharedInstance.game.CreateEntity();
		healthListener.AddCurrentHealthListener(this);
	}

	private void Unbind()
	{
		healthListener.Destroy();
	}

    public void OnCurrentHealth(GameEntity entity, float currentHealth)
    {
		if (entity == owner.GetEntityLink().entity)
        {
            float healthPercentage = currentHealth / entity.maxHealth;
			SetHealthPercentage(healthPercentage);
		}
    }

	public void SetHealthPercentage(float healthPercentage)
	{
		float currentCellPercentage;

		for (int i = 0; i < cells.Length; i++)
		{
            currentCellPercentage = (float)i / cells.Length;
            if (currentCellPercentage >= healthPercentage)
			{
				cells[i].gameObject.SetActive(false);
			}
            else
            {
                cells[i].gameObject.SetActive(true);
                float healthLeftInCellPercentage = healthPercentage - currentCellPercentage;
                SetBarCellColor(cells[i], healthLeftInCellPercentage);
            }
        }
	}

    private void SetBarCellColor(SpriteRenderer cell, float healthLeftInCellPercentage)
    {
        for (int i = cellGradient.Length - 1; i >= 0; i--)
        {
            if (i * cellGradientHealthPercentage <= healthLeftInCellPercentage)
            {
                cell.color = cellGradient[i];
                break;
            }
        }
    }
}
