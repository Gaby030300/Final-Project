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

    [SerializeField] private float checkOffset = 1f;
    [SerializeField] private float checkRadious = 2f;

    
    private GameObject focalPoint;
    [SerializeField] private float dashVelocity = 10.0f;
    private bool isDashing = true;

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
    }

    private void Update()
    {
        Dash();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (shoot.CanShoot())
            {
                shoot.Shoot();
            }
        }
        FollowMouseLook();
        ActivateZipLine();
        
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
        if (Physics.Raycast(ray, out hit))
        {
            rotationTarget = hit.point;
        }
        MovePlayerWithAim();
    }
    public void ActivateZipLine()
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            Debug.Log("hit");
            RaycastHit[] hits = Physics.SphereCastAll(transform.position + new Vector3(0, checkOffset, 0), checkRadious, Vector3.up);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log("hit2");
                if (hit.collider.tag == "Zipline")
                {
                    hit.collider.GetComponent<ZipLine>().StartZipLine(gameObject);
                }
            }
        }
    }
    IEnumerator DashTime() 
    {        
        yield return new WaitForSeconds(3);
        isDashing = true;
    }
}
