using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _sideSpeed = .5f;
    [SerializeField] private float _jumpForce = 5f;

    private PlayerInput inputActions;
    private InputAction movementAction;
    private InputAction jumpAction;

    private Rigidbody rb;
    private Animator animator;

    private Vector3 input;

    private GameManager gameManager;
    private AudioManager audioManager;


    private bool isGrounded = true;
    [Tooltip("Useful for rough ground")]
    public float GroundedOffset = -0.14f;
    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    public float GroundedRadius = 0.5f;
    [Tooltip("What layers the character uses as ground")]
    public LayerMask GroundLayers;

    public GameObject[] collectVFXs;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        movementAction = inputActions.actions["Move"];
        jumpAction = inputActions.actions["Jump"];
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        audioManager = AudioManager.instance;
    }

    private void OnEnable()
    {
        jumpAction.performed += _ => OnJump();
        //movementAction.performed += _ => input = movementAction.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        jumpAction.performed -= _ => OnJump();
       // movementAction.performed -= _ => input = movementAction.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        input = movementAction.ReadValue<Vector2>();
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        isGrounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
    }

    private void FixedUpdate()
    {
        MoveFoward();
        MoveSide(input);
    }

    private void MoveFoward()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }

    private void MoveSide(Vector2 input)
    {
        Vector3 vector3 = new Vector3(input.x, 0, 0);
        transform.Translate(vector3 * _sideSpeed * Time.deltaTime);
    }

    private void OnJump()
    {
        if (isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public void AddReward(int reward)
    {
        audioManager.PlaySound("CollectCoin");
        if (reward > 30)
        {
            int randomVFX = Random.Range(0, collectVFXs.Length);
            collectVFXs[randomVFX].GetComponent<ParticleSystem>().Play();
        }
        gameManager.points += reward;
        gameManager.OnPointChange.Invoke(gameManager.points);
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        audioManager.PlaySound("HitSomething");
        gameManager.OnGameOver.Invoke();
        Debug.Log("Game Over");
    }
}
