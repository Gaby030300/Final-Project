using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenMechanism : MonoBehaviour
{
    public static int keyCount;
    public int maxKey;
    [SerializeField] float xPosition;
    [SerializeField] float yPosition;
    [SerializeField] float zPosition;
    [SerializeField] GameObject light;
    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    private void Update()
    {
        if (keyCount >= maxKey)
        {
            light.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyCount == maxKey)
        {
            keyCount--;
            transform.DOMove(new Vector3(xPosition, yPosition, zPosition), 1);
        }
    }
}
