using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void GameScence()
    {
        animator.SetBool("IsButtonPressed", true);
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(1);
    }
}
