using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleBoss : MonoBehaviour
{
    [SerializeField] public float purpleBossHealth;
    [SerializeField] private GameObject submarine;
    IEnumerator StartCutScene()
    {
        submarine.SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            purpleBossHealth--;
            if(purpleBossHealth == 0)
            {
                StartCoroutine(StartCutScene());
            }
        }
    }
}
