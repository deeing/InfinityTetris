using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int _cols = 15;
    public int cols => _cols;
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private Transform blockSpawner;
    [SerializeField]
    private int numOpenPerRow = 1;
    
    private int rowsGenerated = 0;
    private const float ROW_SPAWN_OFFSET = .05f;

    private HashSet<int> lastRowOpenSlots = new();

    public void Init()
    {
        GenerateRow();
    }

    private HashSet<int> SelectOpenSlots()
    {
        HashSet<int> openSlotsSelected = new();
        
        // figure out with slots are open based on previous last row
        foreach (int prevOpenSlot in lastRowOpenSlots)
        {
            // no more open slots to choose
            if (openSlotsSelected.Count >= numOpenPerRow)
            {
                break;
            }

            int newOpenSlot = prevOpenSlot;
            int diceRoll = Random.Range(0, 3);
            newOpenSlot = diceRoll switch
            {
                0 when prevOpenSlot > 0 => prevOpenSlot - 1,
                2 when prevOpenSlot < cols - 1 => prevOpenSlot + 1,
                _ => newOpenSlot
            };

            openSlotsSelected.Add(newOpenSlot);
        }
        
        // if there are still more to fill then add a new random slot
        if (openSlotsSelected.Count < numOpenPerRow)
        {
            for (int i = openSlotsSelected.Count; i < numOpenPerRow; i++)
            {
                openSlotsSelected.Add(Random.Range(0, cols));
            }
        }
        
        return openSlotsSelected;
    }

    public void GenerateRow()
    {
        HashSet<int> openSlotsSelected = SelectOpenSlots();
        
        for(int i=0; i < cols; i++)
        {
            if (openSlotsSelected.Contains(i))
            {
                continue;
            }
            // TODO: Is this offset weird?
            Vector3 blockPos = new(i, blockSpawner.position.y + ROW_SPAWN_OFFSET, 0f);
            GameObject blockObj = Instantiate(blockPrefab, blockPos, Quaternion.identity, blockSpawner);
            LevelBlock levelBlock = blockObj.GetComponent<LevelBlock>();
            levelBlock.Init(rowsGenerated);
        }

        lastRowOpenSlots = openSlotsSelected;
        rowsGenerated++;
    }
}
