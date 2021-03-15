using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    
    public GameObject greenBlock;
    public GameObject blueBlock;
    public GameObject yellowBlock;
    public GameObject orangeBlock;
    public GameObject redBlock;
    public GameObject purpleBlock;
    public GameObject GetBlock(string colorType,GameObject obj)
    {
        if (colorType == null)
        {
            return null;
        }
        if (colorType.Equals("Green"))
        {
            GameObject block=Instantiate(greenBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Green>().enabled = true;
            return block;
        }
        else if (colorType.Equals("Purple"))
        {
            GameObject block = Instantiate(purpleBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Purple>().enabled = true;
            return block;
        }
        else if (colorType.Equals("Red"))
        {
            GameObject block = Instantiate(redBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Red>().enabled = true;
            return block;
        }
        else if (colorType.Equals("Yellow"))
        {
            GameObject block = Instantiate(yellowBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Yellow>().enabled = true;
            return block;
        }
        else if (colorType.Equals("Orange"))
        {
            GameObject block = Instantiate(orangeBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Orange>().enabled = true;
            return block;
        }
        else if (colorType.Equals("Blue"))
        {
            GameObject block = Instantiate(blueBlock, obj.transform.position, Quaternion.identity);
            block.transform.parent = obj.transform;
            block.GetComponent<Blue>().enabled = true;
            return block;
        }
        return null;
    }
}
