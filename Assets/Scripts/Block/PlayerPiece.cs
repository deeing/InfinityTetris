using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    [SerializeField]
    private PlayerBlock[] _playerBlocks;
    public PlayerBlock[] playerBlocks => _playerBlocks;


    public void Init()
    {
        foreach (PlayerBlock block in playerBlocks)
        {
            block.Init();
        }
    }
}
