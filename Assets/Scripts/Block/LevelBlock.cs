using UnityEngine;

public class LevelBlock : Block
{
    public int rowNumber { get; private set; }
    private GameManager gameManager;

    public void Init(int rowNum)
    {
        rowNumber = rowNum;
        gameManager = GameManager.instance;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * (gameManager.levelBlockSpeed * Time.deltaTime));
    }
}
