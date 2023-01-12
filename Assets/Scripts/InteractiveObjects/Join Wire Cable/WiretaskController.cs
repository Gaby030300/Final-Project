using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiretaskController : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<WireController> _leftWires = new List<WireController>();
    public List<WireController> _rightWires = new List<WireController>();

    public WireController currentDraggedWire;
    public WireController currentHoveredWire;

    private List<Color> _avaliableColor;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;

    public bool isTaskCompleted = false;

    private void Start()
    {
        _avaliableColor = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for(int i = 0; i < _leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }
        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while(_avaliableColor.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0)
        {
            Color pickedColor = _avaliableColor[Random.Range(0, _avaliableColor.Count)];
            int pickedLeftWireIndex = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);

            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _avaliableColor.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        while (!isTaskCompleted)
        {
            int successfulWires = 0;
            for(int i = 0; i < _rightWires.Count; i++)
            {
                if (_rightWires[i].isSuccess)
                {
                    successfulWires++;
                }
                if(successfulWires >= _rightWires.Count)
                {
                    Debug.Log("Task Completed");
                }
                else
                {
                    Debug.Log("Task Incompleted");
                }
                
                yield return new WaitForSeconds(0.5f);
            }

        }
    }
}
