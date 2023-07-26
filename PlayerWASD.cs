using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    private Vector3 moveVector;
    private Rigidbody rb;
    [SerializeField] private float _movespeed;
    [SerializeField] private float _rotatespeed;
    public Animator animator;
    public bool gameoverscreen = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // animator = GetComponent<Animator>();
    }
    void Update()
    {
        //yürüme fonksiyonu updatete çalýþacak
        Move();
    }
    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * _movespeed * Time.deltaTime;
        moveVector.z = Input.GetAxis("Vertical") * _movespeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, _rotatespeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            //animator.SetFloat("Speed", 1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            //animator.SetFloat("Speed", 0);
            animator.SetBool("isWalking", false);
        }
        rb.MovePosition(rb.position + moveVector);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            gameoverscreen = true;
            Time.timeScale = 0;
        }
    }
}
