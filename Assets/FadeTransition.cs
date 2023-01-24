using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] float timeToFade;
    Image image;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b,0), timeToFade);        
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
