using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float hiz = 1f;
    [SerializeField]
    public float jumpForce = 2.0f;
    [SerializeField]
    public float sensivity = 5f;
    [SerializeField]
    public float turnSensivity = 2f;
    [SerializeField]
    public float health = 100;
    public bool isGrounded;

    Rigidbody rb;
    public Vector2 turn;
    public Vector3 jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        float xYon = Input.GetAxis("Horizontal") * hiz;
        float zYon = Input.GetAxis("Vertical") * hiz;
        zYon += Time.deltaTime;
        xYon += Time.deltaTime;
        transform.Translate(xYon, 0, zYon);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        turn.x += Input.GetAxis("Mouse X") * sensivity;
        turn.y += Input.GetAxis("Mouse Y") * sensivity;
        transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);
    }
}

