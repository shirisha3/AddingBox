using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerController : MonoBehaviour
{
    public GameObject box_Prefab;


    public void SpawnBox()
    {
        GameObject box_Obj = (GameObject)Instantiate(box_Prefab).gameObject;
        Vector3 temp_box_Pos = transform.position;
        temp_box_Pos.z = 0;
        box_Obj.transform.position = temp_box_Pos;


    }
   
}
