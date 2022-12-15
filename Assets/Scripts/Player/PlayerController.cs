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
        if (Input.GetKeyDown(KeyCode.E))
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
}
