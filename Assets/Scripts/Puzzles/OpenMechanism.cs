using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMechanism : MonoBehaviour
{
    public static int keyCount;
    public int maxKey;
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyCount == maxKey)
        {
            keyCount--;
            animator.enabled = true;
            Debug.Log("Open Door" + keyCount);
        }
    }
}
