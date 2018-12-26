using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
using UnityEngine.UI;

public abstract class BarBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject owner;
    [SerializeField]
	private GameObject[] cells;
	private SpriteRenderer[] cellsSprites;
	private Image[] cellsImages;

    private GameEntity listenerEntity;
	protected Color[] cellColorGradient;
    private float gradientSingleCellPercentage;

    private void Awake()
    {
        cellColorGradient = GetCellColorGradient();
        gradientSingleCellPercentage = 1f / (cells.Length * cellColorGradient.Length - 1);
        InitCells();
    }

    private void InitCells()
    {
        if (cells.Length == 0)
        {
            return;
        }
        SpriteRenderer sprite = cells[0].GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            InitCellsSprites();
        }
        else
        {
            InitCellsImages();
        }
    }

    private void InitCellsSprites()
    {
        cellsSprites = new SpriteRenderer[cells.Length];
        for (int i = 0; i < cells.Length; i++)
        {
            cellsSprites[i] = cells[i].GetComponent<SpriteRenderer>();
        }
    }
    private void InitCellsImages()
    {
        cellsImages = new Image[cells.Length];
        for (int i = 0; i < cells.Length; i++)
        {
            cellsImages[i] = cells[i].GetComponent<Image>();
        }
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
        EntityLink link;
        if (owner != null
            && (link = owner.GetEntityLink()) != null
            && entity != link.entity)
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
                SetBarCellColor(i, parameterLeftInCellPercentage);
            }
        }
	}

    private void SetBarCellColor(int cellIndex, float parameterLeftInCellPercentage)
    {
        for (int i = cellColorGradient.Length - 1; i >= 0; i--)
        {
            if (i * gradientSingleCellPercentage <= parameterLeftInCellPercentage)
            {
                SetCellColorForProperComponent(cellIndex, cellColorGradient[i]);
                break;
            }
        }
    }

    private void SetCellColorForProperComponent(int cellIndex, Color color)
    {
        if (cellsSprites != null)
        {
            cellsSprites[cellIndex].color = color;
        }
        else if (cellsImages != null)
        {
            cellsImages[cellIndex].color = color;
        }
    }
}
