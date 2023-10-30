using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class MapInteraction : MonoBehaviour
{
    public GameObject waypointPrefab; // Reference to your waypoint prefab
    public float scaleRatio; // Scale ratio of the mini map

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit");
                // If the 3D map is touched
                if (hit.transform == transform)
                {
                    Debug.Log("3D Map touched");

                    MapTouched(hit.point);
                }
            }
        }
    }

    public void MapTouched(Vector3 point)
    {
        scaleRatio = transform.parent.localScale.x;
        // Adjust the position based on the scale ratio
        Vector3 adjustedPosition = (point - transform.parent.position) / (scaleRatio) + GameObject.Find("Terrain").transform.position;

        // Instantiate the waypoint on the real terrain
        Instantiate(waypointPrefab, adjustedPosition, Quaternion.identity);
        GameObject spawnedObject = Instantiate(waypointPrefab, point, Quaternion.identity);
        spawnedObject.transform.localScale *= scaleRatio;
    }

    /*public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        Debug.Log("Touch started");

        // Extract touch position from eventData and convert it to a ray
        Ray ray = Camera.main.ScreenPointToRay(eventData.InputSource.Pointers[0].Result.Details.Point);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit");
            // If the 3D map is touched
            if (hit.transform == transform)
            {
                Debug.Log("3D Map touched");

                scaleRatio = transform.parent.localScale.x;
                // Adjust the position based on the scale ratio
                Vector3 adjustedPosition = (hit.point - transform.parent.position) / (scaleRatio) + GameObject.Find("Terrain").transform.position;

                // Instantiate the waypoint on the real terrain
                Instantiate(waypointPrefab, adjustedPosition, Quaternion.identity);
                GameObject spawnedObject = Instantiate(waypointPrefab, hit.point, Quaternion.identity);
                spawnedObject.transform.localScale *= scaleRatio;
            }
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        Debug.Log("Touch completed");
        // Add handling if needed when touch interaction completes
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        Debug.Log("Touch updated");
        // Add handling if needed when touch interaction is updated
    }*/

}
