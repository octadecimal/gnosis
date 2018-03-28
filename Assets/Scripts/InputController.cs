using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    /// <summary>
    /// The minimum delta of mouse down->up to be registered as a box drag.
    /// </summary>
    public float MinimumRectSize = 10f;

    // Stores the position of the mouse upon mouse down.
    private Vector3 mouseDownPosition;


    // COMPONENT
    // ==================================================================================
	
    /// <summary>
    /// Component update routine.
    /// </summary>
	void Update ()
	{
        HandleMouseButton0();
    }


    // PRIVATE
    // ==================================================================================

    private void HandleMouseButton0()
    {
        // Down
        if (Input.GetMouseButtonDown(0))
        {
            // Save position of cursor on mouse down
            mouseDownPosition = Input.mousePosition;
        }

        // Up
        if(Input.GetMouseButtonUp(0))
        {
            // Calculate delta of mouse down->up
            float downUpDistance = Mathf.Abs(Vector3.Magnitude(Input.mousePosition - mouseDownPosition));

            // If delta exceeded, treat as a box, otherwise treat as a normal click
            if(downUpDistance >= MinimumRectSize)
            {
                Debug.Log("Rect selection.");
                NotificationManager.Broadcast(InputNotifications.RectSelection, new Rect(mouseDownPosition, Input.mousePosition));
            }
            else
            {
                Debug.Log("Selection.");
                NotificationManager.Broadcast(InputNotifications.Selection, Input.mousePosition);
            }
        }
    }
}
