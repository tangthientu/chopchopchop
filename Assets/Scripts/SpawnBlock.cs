using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    
    public GameObject[] blocks;
    public List<GameObject> blockList = new List<GameObject>();
    //int yPos = 50;
    int totalBlock;
    int blockNum;
    int lastBlockId=-1;
    [SerializeField]
    float height;
    [SerializeField]
    int chopId = 5;
    public ScoreManager scoreManager;
     static bool ChangeChopDir = false;
    // Start is called before the first frame update
    void Start()
    {
        blockList = new List<GameObject>();
        blockNum = Random.Range(0, blocks.Length);
        Vector3 down = -transform.up;
         for (int i = 0; i <6; i++)
            {
                float offset = i * 0.5f;
                Vector3 position = transform.position + down * offset;
                GameObject newBlock = Instantiate(blocks[0], position, transform.rotation);
                AddToBlockList(newBlock);
            }
        scoreManager.Score = 0;
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {

            chopBlock();
            addBlock();
        }*/
        //ggggggggggggggggggggggggggggggggggggggggggg
        if (chopId < 0)
        {
            chopId = 1;
            ChangeChopDir = true;
        }
        if(chopId > 6)
        {
            chopId =0   ;
            
        }
        GameObject[] blockToAdd = GameObject.FindGameObjectsWithTag("block");
       /* foreach (GameObject obj in blockToAdd)
        {
            AddToBlockList(obj);
        }
       */
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    void AddToBlockList(GameObject block)
    {
        // Check if the object is already in the list
        if (!blockList.Contains(block))
        {
            // Add the object to the list
            blockList.Add(block);
        }
    }

    void RemoveFromBlockList(GameObject block)
    {
        // Check if the object is in the list
        if (blockList.Contains(block))
        {
            // Remove the object from the list
            blockList.Remove(block);
        }
    }

    void OnDestroy()
    {
        // Remove any destroyed objects from the list
        foreach (GameObject obj in blockList)
        {
            if (obj == null)
            {
                RemoveFromBlockList(obj);
            }
        }
    }
    public void addBlock() 
    {
        Vector3 down = -transform.up;
        // generate a new random index that's not the same as the last one
        int newIndex = Random.Range(0, blocks.Length - 1);
        if (newIndex >= lastBlockId)
        {
            newIndex++; // increment the new index if it points to after the last index
        }
        lastBlockId = newIndex;

        Vector3 position = transform.position + down * 0.5f;
        GameObject newBlock = Instantiate(blocks[newIndex], position, transform.rotation);
        AddToBlockList(newBlock);
        scoreManager.Score++;
        scoreManager.ComboCounter++;
    }
    public void chopBlock()
    {
        // Check if there are any objects in the list
        if (blockList.Count > 0)
        {
            // Destroy the first object in the list
            GameObject objectToDestroy = blockList[chopId];
            Destroy(objectToDestroy);
            blockList.RemoveAt(chopId);
            if (ChangeChopDir == false)
                chopId--;
            else
                chopId = 0;
        }
      

    }
    public void resumeGame()
    {
        Time.timeScale = 1;
    }
}
