using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpawnBlock spawnBlock;
    private void Start()
    {
        spawnBlock = GameObject.Find("Block Spawner").GetComponent<SpawnBlock>();
    }
    public void moveLeft()
    {
        transform.position = new Vector3(-0.734000027f, 0.694f, -6.26999998f);

    }
    public void moveRight()
    {
        transform.position = new Vector3(0.734000027f, 0.694f, -6.26999998f);
    }
    public void playerTap()
    {
        spawnBlock.chopBlock();
        spawnBlock.addBlock();
    }

}
