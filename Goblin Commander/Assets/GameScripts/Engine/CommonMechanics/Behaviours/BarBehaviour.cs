using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;

public abstract class BarBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject owner;
    [SerializeField]
	private SpriteRenderer[] cells;

    private GameEntity listenerEntity;
	protected Color[] cellColorGradient;
    private float gradientSingleCellPercentage;

    private void Awake()
    {
        cellColorGradient = GetCellColorGradient();
        gradientSingleCellPercentage = (float)1 / (cells.Length * cellColorGradient.Length - 1);
    }
    
    protected abstract Color[] GetCellColorGradient();

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
		GameEntity listenerEntity = Contexts.sharedInstance.game.CreateEntity();
        this.listenerEntity = AttachListenerComponent(listenerEntity);
	}

    protected abstract GameEntity AttachListenerComponent(GameEntity listenerEntity);

	private void Unbind()
	{
        if (listenerEntity == null)
        {
            return;
        }
		listenerEntity.Destroy();
	}

    protected void OnParameterChanged(GameEntity entity, float currentParameterValue)
    {
        if (entity != owner.GetEntityLink().entity)
        {
            return;
        }

        float parameterPercentage = currentParameterValue / GetParameterMaxValue(entity);
		SetParameterPercentage(parameterPercentage);
    }

    protected abstract float GetParameterMaxValue(GameEntity entity);

	private void SetParameterPercentage(float parameterPercentage)
	{
		float currentCellPercentage;

		for (int i = 0; i < cells.Length; i++)
		{
            currentCellPercentage = (float)i / cells.Length;
            if (currentCellPercentage >= parameterPercentage)
			{
				cells[i].gameObject.SetActive(false);
			}
            else
            {
                cells[i].gameObject.SetActive(true);
                float parameterLeftInCellPercentage = parameterPercentage - currentCellPercentage;
                SetBarCellColor(cells[i], parameterLeftInCellPercentage);
            }
        }
	}

    private void SetBarCellColor(SpriteRenderer cell, float parameterLeftInCellPercentage)
    {
        for (int i = cellColorGradient.Length - 1; i >= 0; i--)
        {
            if (i * gradientSingleCellPercentage <= parameterLeftInCellPercentage)
            {
                cell.color = cellColorGradient[i];
                break;
            }
        }
    }
}
