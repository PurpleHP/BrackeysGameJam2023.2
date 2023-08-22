using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SaveCoin speedLevel;
    private int[] realSpeed = { 4, 6, 8, 10 }; //Depth Calculator'dan da deðiþtirilmeli
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
    }
    void Update()
    {
        if ((PlayerPrefs.HasKey("Speed")))
        {
            Debug.Log(speedLevel.speedLevel + "laaaaaaaaaaaaan");
            speed = realSpeed[speedLevel.speedLevel];
        }
        else
        {
            Debug.Log("Bulunamadý");
            speed = realSpeed[0];
        }
        Debug.Log(speed);
        if (transform.rotation.z > 0.70 || transform.rotation.z < -0.70)
        {
            _submarine.flipY = true;
        }
        else
        {
            _submarine.flipY = false;
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
