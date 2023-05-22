using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpawnBlock spawnBlock;
    Animator animator;
    public ParticleSystem left;
    public ParticleSystem right;
    public static bool animationToggle;
    private void Start()
    {
        spawnBlock = GameObject.Find("Block Spawner").GetComponent<SpawnBlock>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
       
    }
    public void moveLeft()
    {
        transform.position = new Vector3(-0.484f, transform.position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 90, 0);
        left.Play();

    }
    public void moveRight()
    {
        transform.position = new Vector3(0.484f, transform.position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, -90, 0);
        right.Play();
    }
    public void playerTap()
    {
        spawnBlock.chopBlock();
        spawnBlock.addBlock();
    }
    public void changeAnimation()
    {
        animationToggle = !animationToggle;
        if (animationToggle)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            Debug.Log("1");
            right.Play();
        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            Debug.Log("2");
            left.Play();
        }
       
    }
}
