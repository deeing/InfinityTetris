using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : Block
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    public void Init()
    {
        gameManager = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, -gameManager.playerBlockSpeed, 0); // Move down at a constant speed
    }
}
