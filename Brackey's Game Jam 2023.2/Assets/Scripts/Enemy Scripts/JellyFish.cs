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
    [SerializeField] BoxCollider2D AttackRange;
    private bool Iswalk = false;
    private enum MovementState {idle, walk, hurt, death}
    private MovementState state;

    private Animator anim;
    private float distance;
    private void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        JellyFishMovement();
        UpdateAnimationState();
        Debug.Log("state " + state);
    }
    private void JellyFishMovement()
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
            state = MovementState.walk;
        }
        else
        {
            state = MovementState.idle;
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (Iswalk)
        {
            state = MovementState.walk;
        }
        else
        {
            state = MovementState.idle;
        }
    }

}
