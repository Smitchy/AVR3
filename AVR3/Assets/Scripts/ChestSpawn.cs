using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ChestSpawn : MonoBehaviour, IInputHandler{

    public GameObject chest;
    public Transform cameraPos, cursorPos;
    private bool spawned = false;
    public GameObject rules;

    void Start()
    {
        rules.SetActive(true);
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (spawned) return;
        RaycastHit hit;
        if (Physics.Raycast(cameraPos.position, cursorPos.position-cameraPos.position, out hit))
        {
            Instantiate(chest, hit.point + new Vector3(0, 0.185f, 0), Quaternion.Euler(0f, 180f, 0f));
            rules.SetActive(false);
            spawned = true;
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        return;
    }
}
