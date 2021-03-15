using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Blocks
{
    private void Start()
    {
        color = "Blue";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
}
