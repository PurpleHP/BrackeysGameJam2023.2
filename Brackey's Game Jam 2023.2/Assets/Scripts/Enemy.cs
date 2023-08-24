using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float enemyScale;
    [SerializeField] public float maxHealth;
    [SerializeField] public float health;
    [SerializeField] BoxCollider2D box2d1;
    [SerializeField] BoxCollider2D box2d2;

    private Animator anim;
    private float distance;
    private void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }
    void Update()
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
            anim.SetBool("StartWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            anim.SetBool("StartWalking", false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                speed = 0;
                box2d1.enabled = false;
                box2d2.enabled = false;
                anim.SetBool("IsHurt", true);
                anim.SetBool("IsDead", true);
                Destroy(gameObject, 1.7f);

            }
            else
            {
                anim.SetTrigger("IsHurt1");
            }
        }
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Attacking1");
        }
    }
}
