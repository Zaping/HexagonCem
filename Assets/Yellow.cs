using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Blocks
{
    private void Start()
    {
        color = "Yellow";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
    
}

