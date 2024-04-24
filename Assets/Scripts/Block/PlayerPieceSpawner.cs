using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfinityTetris;

public class PlayerPieceSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] possiblePieces;

    public void Init()
    {
        
    }

    public PlayerPiece GenerateRandomPiece()
    {
        GameObject pieceObj = Instantiate(possiblePieces.RandomElement(), transform);
        PlayerPiece piece = pieceObj.GetComponent<PlayerPiece>();
        
        return piece;
    }
}
