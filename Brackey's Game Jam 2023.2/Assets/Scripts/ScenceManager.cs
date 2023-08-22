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
    IEnumerator WaitForAnimation()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }
    public void GameScence()
    {
        animator.SetBool("IsButtonPressed", true);
        Debug.Log("Button Pressed");
        StartCoroutine(WaitForAnimation());

    }

    public void ShopMenu()
    {
        SceneManager.LoadScene(2);

    }
    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
