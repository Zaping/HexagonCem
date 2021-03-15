using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Blocks
{
    private void Start()
    {
        color = "Red";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
}
