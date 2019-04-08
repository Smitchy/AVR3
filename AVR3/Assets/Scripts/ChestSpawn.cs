using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour {

    public GameObject chest;
    public Transform cameraPos;

	void Start () {
        SpawnChest();
    }
	
    void SpawnChest()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraPos.position + new Vector3(0, 0, 3), -Vector3.up, out hit))
        {
                Instantiate(chest, hit.point, Quaternion.identity);
        }
    }
}
