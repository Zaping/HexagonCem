using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Blocks
{
    private void Start()
    {
        color = "Green";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
}
