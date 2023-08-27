using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;

    public float totalTimer;

    [SerializeField] PlaySound sfx;


    [SerializeField] RectTransform fader;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Timer"))
        {
            totalTimer = PlayerPrefs.GetFloat("Timer");
        }
        else
        {
            PlayerPrefs.SetFloat("Timer", 0);
        }
        fader.gameObject.SetActive(true);

        LeanTween.alpha (fader, 1, 0);
        LeanTween.alpha (fader, 0, 0.5f).setOnComplete (() => {
        fader.gameObject.SetActive (false);
        });
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "FinalScene")
        {
            totalTimer += Time.deltaTime;
            PlayerPrefs.SetFloat("Timer", totalTimer);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
    /*
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }*/

    public void GameScence()
    {
        animator.SetBool("IsButtonPressed", true); //???
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 1f).setOnComplete(() => {
            // Example for little pause before laoding the next scene
            Invoke("LoadGame", 1f);
        });


    }

    public void PlayerDeath()
    {
        fader.gameObject.SetActive(true);
        sfx.PlayDeath();

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() => {
            // Example for little pause before laoding the next scene
            Invoke("LoadGame", 1f);
        });


    }
    public void ShopMenu()
    {
        fader.gameObject.SetActive(true);
         
         LeanTween.alpha (fader, 0, 0);
         LeanTween.alpha (fader, 1, 0.5f).setOnComplete (() => {
             // Example for little pause before laoding the next scene
             Invoke ("LoadShop", 0.5f);
        });

    }
    public void MainMenu()
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() => {
            // Example for little pause before laoding the next scene
            Invoke("LoadMenu", 0.5f);
        });


    }

    public void FinalScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() => {
            // Example for little pause before laoding the next scene
            Invoke("LoadFinal", 0.5f);
        });


    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadShop()
    {
        SceneManager.LoadScene(2);

    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);

    }
    private void LoadFinal()
    {
        SceneManager.LoadScene(3);

    }
}
