using UnityEngine;

// A simple 2D movement controller for a player in Unity
public class PlayerMovementController : MonoBehaviour
{
    #region Gameplay properties

    // Horizontal player keyboard input
    //  -1 = Left
    //   0 = No input
    //   1 = Right
    private float playerInput = 0;

    // Horizontal player speed
    [SerializeField] private float speed = 250;

    #endregion

    #region Component references

    private Rigidbody2D rb;

    #endregion

    #region Initialisation methods

    // Initialises this component
    // (NB: Is called automatically before the first frame update)
    void Start()
    {
        // Get component references
        rb = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Gameplay methods

    // Is called automatically every graphics frame
    void Update()
    {
        // Detect and store horizontal player input   
        playerInput = Input.GetAxisRaw("Horizontal");

        // NB: Here, you might want to set the player's animation,
        // e.g. idle or walking

        // Swap the player sprite scale to face the movement direction
        SwapSprite();
    }

    // Swap the player sprite scale to face the movement direction
    void SwapSprite()
    {
        // Right
        if (playerInput > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        // Left
        else if (playerInput < 0)
        {
            transform.localScale = new Vector3(
                -1 * Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    // Is called automatically every physics step
    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(
            playerInput * speed * Time.fixedDeltaTime,
            0
        );
    }

    #endregion
}