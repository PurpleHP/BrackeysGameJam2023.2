using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SaveCoin speedLevel;
    [SerializeField] private SpriteRenderer _ryanGosling;
    private int[] realSpeed = { 4, 6, 8, 10 }; //SaveCoin'den da deðiþtirilmeli
    public float speed;
    public float forceDamping = 0.05f;
    private Rigidbody2D rb;
    private Vector2 forceToApply;
    private Transform m_transform;
    private SpriteRenderer _submarine;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_transform = transform;
        _submarine = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("Speed"))
        {
            speed = PlayerPrefs.GetInt("Speed");
        }
        else
        {
            speed = realSpeed[0];
        }
    }
    void Update()
    {
        Debug.Log(speed);
        if (transform.rotation.z > 0.70 || transform.rotation.z < -0.70)
        {
            _submarine.flipY = true;
            _ryanGosling.flipY = true;
        }
        else
        {
            _submarine.flipY = false;
            _ryanGosling.flipY = false;

        }
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = playerInput * speed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        if (forceToApply.magnitude <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }

        rb.velocity = moveForce;

        LAMouse();
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 0, Vector3.forward);
        m_transform.rotation = rotation;

        // Add code here to handle shooting or whatever the intention of this function is
    }
}
