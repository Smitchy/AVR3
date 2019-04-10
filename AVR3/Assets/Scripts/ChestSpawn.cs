using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ChestSpawn : MonoBehaviour, IInputHandler{

    public GameObject chest;
    public Transform cameraPos, cursorPos;
    private bool spawned = false;

	void Start () {
        SpawnChest();
    }
	
    void SpawnChest()
    {
        
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (spawned) return;
        RaycastHit hit;
        if (Physics.Raycast(cameraPos.position, cursorPos.position-cameraPos.position, out hit))
        {
            Instantiate(chest, hit.point, Quaternion.Euler(0f, 180f, 0f));
            spawned = true;
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        return;
    }
}
