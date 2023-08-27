using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float enemyScale;
    [SerializeField] GameObject dialoguePanel;
    


    private Animator anim;
    public bool isDead = false;
    private float distance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("10.1"))
        {
            if(PlayerPrefs.GetFloat("10.1") == 0)
            {
                speed = 0;
                gameObject.SetActive(false);

            }
        }
    }
    void Update()
    {
        if(speed != 0)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if ((transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 270))
            {

                transform.localScale = new Vector3(enemyScale, -enemyScale, enemyScale);

            }
            else
            {
                transform.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
            }

            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
       

    }
    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            speed = 0;
            StartCoroutine(Dissappear());
        }
    }
}
