using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float enemyScale;
    [SerializeField] float health;
    private Animator anim;
    private float distance;
    private BoxCollider2D box2d;
    private void Awake()
    {
        box2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
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
    IEnumerator WaitFor1Seconds()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                box2d.isTrigger = true;
                anim.SetTrigger("IsDead1");
                Destroy(gameObject,1f);
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
