using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Checkpoints : MonoBehaviour
{
    [SerializeField] GameObject[] checks;

    [SerializeField] GameObject checkText;
    private bool checkPointTextCanBeVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Checkpoint")){
            int checkpointNum = PlayerPrefs.GetInt("Checkpoint");
            gameObject.transform.position = checks[checkpointNum].transform.position;
        }
        StartCoroutine(CheckpointCooldown());
        
    }
    IEnumerator CheckpointCooldown()
    {
        yield return new WaitForSeconds(2f);
        checkPointTextCanBeVisible = true;
    }
    IEnumerator ShowText()
    {
        checkText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        checkText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            for(int i = 0; i < checks.Length; i++)
            {
                //if (collision.gameObject.name.Equals($"{checks[i]}"))
                if (collision.gameObject.name.Equals($"Checkpoint{i+1}"))
                {
                    if(collision.gameObject.GetComponent<SpriteRenderer>().color != Color.green && checkPointTextCanBeVisible)
                    {
                        StartCoroutine(ShowText());
                    }
                    PlayerPrefs.SetInt("Checkpoint", i);
                    //collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 144, 144);
                    collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    //collision.gameObject.GetComponent<SpriteRenderer>().color = Color(255, 129, 129);
                    checks[i].GetComponent<SpriteRenderer>().color = Color.red;

                }
            }

        }
    }
}
