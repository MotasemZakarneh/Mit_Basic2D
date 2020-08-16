using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveForce = 50;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] BoxCollider2D feet = null;

    [SerializeField] AudioClip jumpSFX = null;
    [SerializeField] AudioClip resetSFX = null;

    Rigidbody2D rb2d = null;
    Animator animator = null;
    SpriteRenderer sr = null;
    PlayerGhost ghost = null;

    Vector2 input = Vector2.zero;
    bool isGrounded = false;
    LevelTimer levelTimer = null;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ghost = GetComponent<PlayerGhost>();
        levelTimer = FindObjectOfType<LevelTimer>();
    }
    void Update()
    {
        if (levelTimer.IsTimeUp)
            return;
        input.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.Space) && !ghost.IsGhost)
        {
            if (isGrounded)
            {
                Vector2 jumpForce = Vector2.up * jumpSpeed;
                rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
                SFXManager.PlaySFX(jumpSFX);
            }
        }
        if (ghost.IsGhost)
        {
            input.y = Input.GetAxisRaw("Vertical");
            isGrounded = false;
        }
        else
            input.y = 0;
    }
    void FixedUpdate()
    {
        if (levelTimer.IsTimeUp)
        {
            rb2d.simulated = false;
            rb2d.velocity = Vector2.zero;
            return;
        }
        Vector2 forceDir = input;
        rb2d.AddForce(forceDir * moveForce);
        if (ghost.IsGhost)
        {
            GhostClamping();
        }
        else
        {
            StandardClamping();
        }

        Collider2D[] overlaps = Physics2D.OverlapBoxAll(feet.transform.position, feet.size, 0);
        foreach (var overlap in overlaps)
        {
            if (overlap.CompareTag("Ground") && rb2d.velocity.y <= 0.1f)
            {
                isGrounded = true;
            }
        }
    }

    private void StandardClamping()
    {
        Vector2 xVel = rb2d.velocity;
        xVel.y = 0;
        xVel = Vector2.ClampMagnitude(xVel, maxSpeed);
        Vector2 yVel = rb2d.velocity;
        yVel.x = 0;
        rb2d.velocity = xVel + yVel;
    }
    private void GhostClamping()
    {
        rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity, maxSpeed);
    }

    public void ResetPlayer()
    {
        ghost.ResetGhost();
        rb2d.velocity = Vector2.zero;

        SFXManager.PlaySFX(resetSFX);
    }
}