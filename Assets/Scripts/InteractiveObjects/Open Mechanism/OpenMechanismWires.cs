using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class OpenMechanismWires : MonoBehaviour
{
    [SerializeField] float xPosition;
    [SerializeField] float yPosition;
    [SerializeField] float zPosition;
    public bool canMove;

    [SerializeField] SceneLoaderCollider open;

    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canMove)
        {
            transform.DOMove(new Vector3(xPosition, yPosition, zPosition), 1);
        }
    }

    public void AllowToMove()
    {
        canMove = true;
        open.enabled = false;
    }
}
