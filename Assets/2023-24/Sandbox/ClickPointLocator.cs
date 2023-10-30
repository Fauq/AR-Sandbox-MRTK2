using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class ClickPointLocator : MonoBehaviour, IMixedRealityPointerHandler
{
    private MapInteraction mi;
    public void Start()
    {
        mi = gameObject.GetComponent<MapInteraction>();
    }
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // Get the hit information from the event data
        Vector3 hitPosition = eventData.Pointer.Result.Details.Point;

        // You now have the local position of the hit
        Debug.Log("Clicked at local position: " + hitPosition);

        mi.MapTouched(hitPosition);
    }

    // Other event functions you might want to implement
    public void OnPointerDown(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
}
