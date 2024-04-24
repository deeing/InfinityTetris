using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GridManager gridManager;

    private readonly HashSet<int> generatedRows = new();

    private void OnTriggerExit2D(Collider2D other)
    {
        LevelBlock levelBlock = other.GameObject().GetComponent<LevelBlock>();

        if (levelBlock == null || generatedRows.Contains(levelBlock.rowNumber))
        {
            return;
        }
        gridManager.GenerateRow();
        generatedRows.Add(levelBlock.rowNumber);
    }
}
