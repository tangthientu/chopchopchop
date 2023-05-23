using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    AudioSource bonk;
    public Animator animator;
    public Transform player;
    public GameObject gameoverScr,tapArea;
    private void Start()
    {
        bonk = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("deadzone"))
        {
            gameOver();
        }
    }
    public void tryAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void gameOver()
    {
        Debug.Log("gameover");
        bonk.Play();
        player.localRotation = Quaternion.Euler(0, 180, 0);
        animator.Play("gameover");
        gameoverScr.SetActive(true);
        tapArea.SetActive(false);
    }
}
