using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{    
    public float speed;
    private Vector2 move, mouseLook;
    private Vector3 rotationTarget;
    Rigidbody rb;
    private ShootController shoot;
    [SerializeField]LayerMask layer;

    [SerializeField] private float checkOffset = 1f;
    [SerializeField] private float checkRadious = 2f;

    
    private GameObject focalPoint;
    [SerializeField] private float dashVelocity = 10.0f;
    private bool isDashing = true;

    [SerializeField] Animator animPlayer;
    Transform cam;
    Vector3 camForward;
    Vector3 moveAnimator;
    Vector3 moveInput;

    float forwardAmount;
    float turnAmount;

    public bool isDeath;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }
    void Awake()
    {
        shoot = GetComponent<ShootController>();
    }
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       focalPoint = GameObject.Find("_Outpoint");

        cam = Camera.main.transform;
    }

    private void Update()
    {
        Dash();
    }

    void FixedUpdate()
    {
        if (!isDeath)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (cam != null)
        {
            camForward = Vector3.Scale(cam.up, new Vector3(1, 0, 1)).normalized;
            moveAnimator = vertical * camForward + horizontal * cam.right;
        }
        else
        {
            moveAnimator = vertical * Vector3.forward + horizontal * Vector3.right;
        }

        if (moveAnimator.magnitude > 1)
        {
            moveAnimator.Normalize();
        }
        Move(moveAnimator);
        Shooting();
        FollowMouseLook();
        ActivateZipLine();
    }    

    public void Shooting()
    {
        if (Input.GetButton("Fire1"))
        {
            if (shoot.CanShoot())
            {
                shoot.Shoot();
            }
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDashing)
        {
            rb.AddForce(focalPoint.transform.forward * dashVelocity, ForceMode.Impulse);
            isDashing = false;
            StartCoroutine(DashTime());
        }        
    }
    public void MovePlayerWithAim()
    {
        var lookPos = rotationTarget - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);
        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }        
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);        

    }
    public void FollowMouseLook()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseLook);
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,layer))
        {
            rotationTarget = hit.point;
        }
        MovePlayerWithAim();
    }
    public void ActivateZipLine()
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position + new Vector3(0, checkOffset, 0), checkRadious, Vector3.up);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "Zipline")
                {
                    hit.collider.GetComponent<ZipLine>().StartZipLine(gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            OpenMechanism.keyCount++;
            Destroy(other.gameObject);
            Debug.Log(OpenMechanism.keyCount);
        }
    }

    IEnumerator DashTime() 
    {        
        yield return new WaitForSeconds(3);
        isDashing = true;
    }

    public void StopMoving()
    {
        StartCoroutine(SpeedSlow());
    }

    IEnumerator SpeedSlow()
    {
        animPlayer.SetBool("TakingDamage",true);
        speed /= 100;
        yield return new WaitForSeconds(1.5f);
        speed *= 100;
        animPlayer.SetBool("TakingDamage",false);
    }

    void Move(Vector3 move)
    {
        if(move.magnitude > 1)
        {
            move.Normalize();
        }

        this.moveInput = move;
        ConvertMoveInput();
        UpdateAnimator();
    }

    void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;

        forwardAmount = localMove.z;
    }
    void UpdateAnimator()
    {
        animPlayer.SetFloat("Forward",forwardAmount, 0.1f, Time.deltaTime);
        animPlayer.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    public void DieAnimation()
    {
        isDeath = true;
        animPlayer.SetBool("IsDeath", isDeath);
    }
}
