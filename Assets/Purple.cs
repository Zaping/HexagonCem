using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : Blocks
{
    private void Start()
    {
        color = "Purple";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
}
