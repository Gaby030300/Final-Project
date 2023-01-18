using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZipLine : MonoBehaviour
{
    [SerializeField] private ZipLine targetZip;
    [SerializeField] private float speedZip = 3f;
    [SerializeField] private float zipScale = 0.2f;

    [SerializeField] private float arrivalThreshold = 0.4f;
    [SerializeField] private LineRenderer cable;

    public Transform ZipTransform;

    private bool isZipping = false;
    private GameObject localZip;

    private void Awake()
    {
        cable.SetPosition(0, ZipTransform.position);
        cable.SetPosition(1, targetZip.ZipTransform.position);
    }

    void Update()
    {
        if(!isZipping || localZip == null) return;
        localZip.GetComponent<Rigidbody>().AddForce((targetZip.ZipTransform.position - ZipTransform.position).normalized * speedZip * Time.deltaTime, ForceMode.Acceleration);
        if(Vector3.Distance(localZip.transform.position, targetZip.ZipTransform.position) <= arrivalThreshold)
        {
            ResetZipLine();
        }
    }
    public void StartZipLine(GameObject player)
    {
        if (isZipping) return;

        localZip = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        localZip.transform.position = ZipTransform.position;
        localZip.transform.localScale = new Vector3(zipScale, zipScale, zipScale);
        localZip.AddComponent<Rigidbody>().useGravity = false;        
        localZip.GetComponent<Collider>().isTrigger = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.parent = localZip.transform;
        player.transform.position = localZip.transform.position + new Vector3(0,-3,0);
        isZipping = true;
    }
    private void ResetZipLine()
    {
        if (!isZipping) return;

        GameObject player = localZip.transform.GetChild(0).gameObject;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerInput>().enabled = true;
        player.transform.parent = null;
        Destroy(localZip);
        localZip = null;
        isZipping = false;
    }
}
