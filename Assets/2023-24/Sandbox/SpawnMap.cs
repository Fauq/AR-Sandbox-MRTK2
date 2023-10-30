using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject mapPrefab; // Reference to your 3D map prefab

    public void Spawn()
    {
        // Spawn the 3D map in front of the camera
        GameObject spawnedMap = Instantiate(mapPrefab, Camera.main.transform.position + Camera.main.transform.forward * 2 + new Vector3(0, -0.5f, 0), Quaternion.identity);
    }
}
