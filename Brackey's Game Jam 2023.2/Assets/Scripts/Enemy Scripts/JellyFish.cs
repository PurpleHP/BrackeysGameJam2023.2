using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float enemyScale;
    [SerializeField] public float maxHealth;
    [SerializeField] public float health;
    [SerializeField] BoxCollider2D box2d1;
    [SerializeField] BoxCollider2D box2d2;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] string enemyType;
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
            //anim.SetBool(enemyType + "IsWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            //anim.SetBool(enemyType + "IsWalk", false);
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
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                anim.SetTrigger(enemyType + "IsDead");
                //anim.SetBool(enemyType + "IsHurt", true);
                //anim.SetBool(enemyType + "IsDead", true);
                Destroy(gameObject, 1.7f);

            }
            else if (health > 0)
            {
                anim.SetTrigger(enemyType + "IsHurt");
            }
        }
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger(enemyType + "IsAttack");
        }
    }
}
