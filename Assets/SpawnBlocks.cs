
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField]private GameObject[] columns=new GameObject[] { };
    
    string[] colors = new string[] {"Blue","Yellow","Green","Purple","Red","Orange" };
    int randomColor;
    BlockFactory blockFactory;
    public Text scoreText;
    int counter;
    void Start()
    {
        counter = 0;
        blockFactory = transform.GetComponent<BlockFactory>();                                  
    }
    public void SpawnBlock(int columnNumber)
    {
        counter++;
        scoreText.text = (counter*5).ToString();
        Spawn(columnNumber);
    }
    public void Spawn(int spawnColumn)
    {                                 
        randomColor = Random.Range(0, 5);
        GameObject block = blockFactory.GetBlock(colors[randomColor], columns[spawnColumn - 1]);          
        block.GetComponent<Blocks>().columnNumber = spawnColumn;        
    }    
}
    

