using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapcontroller : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<draggable> draggableObjects;

    public float snapRange = 0.5f;

    private void Start()
    {
        foreach (draggable drag in draggableObjects)
        {
            drag.dragEndedCallBack = OnDragEnded;

        }
    }

        private void OnDragEnded(draggable drag)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(drag.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            drag.transform.localPosition = closestSnapPoint.localPosition;
        }
    } 


}
