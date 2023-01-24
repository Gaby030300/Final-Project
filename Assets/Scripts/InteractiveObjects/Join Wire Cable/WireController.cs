using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WireController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool IsLeftWire;
    public Color CustomColor;

    private Image _image;
    private LineRenderer _lineRenderer;

    private Canvas _canvas;
    private bool _isDragStarted = false;
    private WiretaskController _wireTask;
    public bool isSuccess = false;

    public bool trigered;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WiretaskController>();
    }

    private void Update()
    {
        if (_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        _canvas.transform as RectTransform,
                        Input.mousePosition,
                        _canvas.worldCamera,
                        out movePos);
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1,
                 _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            // Hide the line if not dragging.
            // We will not hide it when it connects, later on.
            if (!isSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }
        bool isHovered =
          RectTransformUtility.RectangleContainsScreenPoint(
              transform as RectTransform, Input.mousePosition,
                                      _canvas.worldCamera);
        if (isHovered)
        {
            _wireTask.currentHoveredWire = this;
        }
    }


    public void SetColor(Color color)
    {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        CustomColor = color;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // needed for drag but not used
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLeftWire) { return; }
        // Is is successful, don't draw more lines!
        if (isSuccess) { return; }
        _isDragStarted = true;
        _wireTask.currentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.currentHoveredWire != null)
        {
            if (_wireTask.currentHoveredWire.CustomColor ==
                                                   CustomColor &&
                !_wireTask.currentHoveredWire.IsLeftWire)
            {
                isSuccess = true;
                // Set Successful on the Right Wire as well.
                _wireTask.currentHoveredWire.isSuccess = true;                
            }
        }
        _isDragStarted = false;
        _wireTask.currentDraggedWire = null;
    }
}
