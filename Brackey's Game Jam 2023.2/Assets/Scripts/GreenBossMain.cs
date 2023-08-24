using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossMain : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float enemyScale;
    [SerializeField] public float maxHealth;
    [SerializeField] private float health;
    [SerializeField] CircleCollider2D box2d1;
    [SerializeField] CircleCollider2D box2d2;
    [SerializeField] GreenBossRoom room;
    [SerializeField] GameObject child1;
    [SerializeField] GameObject child2;

    private Animator anim;
    public bool isDead = false;
    private float distance;
    private bool finalShot = false;
    private void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(health);
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
    IEnumerator WaitTillBossDeath()
    {
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(3);
        isDead = true;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0 && !finalShot)
            {
                finalShot = true;
                room.isOnGreenBoss = false;
                speed = 0;
                box2d1.enabled = false;
                box2d2.enabled = false;
                StartCoroutine(WaitTillBossDeath());

            }
            else if(health * 2 == maxHealth)
            {
                child1.SetActive(true);
                child2.SetActive(true);
            }
        }
    }
}
