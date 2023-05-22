using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopBlock : MonoBehaviour
{
    SpawnBlock spawnBlock;
    private void Start()
    {
        spawnBlock = GameObject.Find("Block Spawner").GetComponent<SpawnBlock>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnBlock.chopBlock();
            spawnBlock.addBlock();
        }
    }
}
