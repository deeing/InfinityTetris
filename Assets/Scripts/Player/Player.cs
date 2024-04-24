using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerPiece currentPiece;
    
    public void Init()
    {
        
    }

    private void Update()
    {
        if (!GameManager.instance.gameStarted)
        {
            return;
        }

        if (currentPiece == null)
        {
            GetNewPiece();
        }
    }

    private void GetNewPiece()
    {
        currentPiece = GameManager.instance.playerPieceSpawner.GenerateRandomPiece();
        currentPiece.Init();
    }
}
