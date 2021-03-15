using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Blocks
{
    private void Start()
    {
        color = "Orange";
        GameManager = transform.parent.parent;
        spawn = GameManager.GetComponent<SpawnBlocks>();
    }
}
