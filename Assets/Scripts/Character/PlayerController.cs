using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float MoveSpeed = 10f;
    [SerializeField] float verticalSpeed = 2.5f;
    [SerializeField] float jumpForce = 24f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundRadious = 2f;
    [SerializeField] Button buttonVirtualLeft;
    [SerializeField] Button buttonVirtualRight;
    public Animator animator;
    public bool CanWeGoVertical { get; set; }
    public bool CanWeTakeAnObject { get; set; }
    public bool IsWeHoldAnObject { get; set; }
    public Rigidbody2D rb { get; private set; }
    public UnityEvent onTakeKeyPressed;
    public UnityEvent onThrowKeyPressed;
    public UnityEvent onPushKeyPressed;
    public bool facingRight = true;
    public bool isPushing { get; private set; }
    public bool isGrounded;
    private float startSpeed;
    private float startJumpForce;

    private bool isRestarting = false;
    private float heldTime = 0f;
    private const float restartTimeThreshold = 1f;

    private float lastJumpTime;

    private float jumpTime = 0f;

    float horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Add event triggers for the virtual buttons
        AddEventTrigger(buttonVirtualLeft.gameObject, EventTriggerType.PointerDown, (data) => VirtualLeft(true));
        AddEventTrigger(buttonVirtualLeft.gameObject, EventTriggerType.PointerUp, (data) => VirtualLeft(false));
        AddEventTrigger(buttonVirtualRight.gameObject, EventTriggerType.PointerDown, (data) => VirtualRight(true));
        AddEventTrigger(buttonVirtualRight.gameObject, EventTriggerType.PointerUp, (data) => VirtualRight(false));
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, groundLayer);

        if (!isGrounded)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime >= 1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, -9);
            }
        }

        if (isGrounded && jumpTime != 0)
        {
            jumpTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VirtualJump();
        }

        // Update horizontal input from keyboard
        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }

    public void VirtualJump()
    {
        if (isGrounded)
        {
            if (Time.time - lastJumpTime < 0.5f)
            {
                animator.SetTrigger("LedgeClimbing");
            }
            else
            {
                animator.SetTrigger("Jump");
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            lastJumpTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        float move = moveDirection.x * MoveSpeed;
        rb.velocity = new Vector2(moveDirection.x * MoveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0.1f || rb.velocity.x < -0.1f)
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (CanWeGoVertical)
        {
            rb.gravityScale = 0;
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 moveDirectionVertical = new Vector2(0, verticalInput);
            float moveVertical = moveDirectionVertical.y * verticalSpeed;
            rb.velocity = new Vector2(rb.velocity.x, moveDirectionVertical.y * verticalSpeed);
        }
        else
        {
            rb.gravityScale = 5;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StopCharacter()
    {
        startSpeed = MoveSpeed;
        startJumpForce = jumpForce;
        MoveSpeed = 0;
        jumpForce = 0;
    }

    public void CharacterCanGo()
    {
        MoveSpeed = startSpeed;
        jumpForce = startJumpForce;
    }

    public void VirtualLeft(bool isPressed)
    {
        horizontalInput = isPressed ? -1f : 0f;
    }

    public void VirtualRight(bool isPressed)
    {
        horizontalInput = isPressed ? 1f : 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerPress == buttonVirtualLeft.gameObject)
        {
            VirtualLeft(true);
        }
        else if (eventData.pointerPress == buttonVirtualRight.gameObject)
        {
            VirtualRight(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerPress == buttonVirtualLeft.gameObject)
        {
            VirtualLeft(false);
        }
        else if (eventData.pointerPress == buttonVirtualRight.gameObject)
        {
            VirtualRight(false);
        }
    }

    private void AddEventTrigger(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        var entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
}
