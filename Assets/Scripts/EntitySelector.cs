using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySelector : MonoBehaviour
{
    Texture2D texture;
    bool isSelecting;
    Vector3 mousePositionStart;

    EntityController entities;

	void Start ()
    {
        entities = GetComponent<EntityController>();

        Debug.Assert(entities != null, "Null entities");

        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
	}

    void OnGUI()
    {
        if(isSelecting)
        {
            Rect rect = GetScreenRect(mousePositionStart, Input.mousePosition);
            DrawScreenRect(rect, new Color(0f, 1f, 0f, 0.1f));
            DrawScreenRectBorder(rect, 2, Color.green);
        }
    }

    void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mousePositionStart = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            foreach(GameObject entity in entities.Entities)
            {
                entity.GetComponent<Entity>().Deselect();

                if (IsWithinSelectionBounds(entity))
                {
                    entity.GetComponent<Entity>().Select();
                }
            }

            isSelecting = false;
        }
	}

    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if(!isSelecting)
        {
            return false;
        }

        var camera = Camera.main;
        var bounds = GetViewportBounds(camera, mousePositionStart, Input.mousePosition);

        return bounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
    }

    void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, texture);
        GUI.color = Color.white;
    }

    void DrawScreenRectBorder(Rect rect, float thickness, Color color)
    {
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;

        var topLeft = Vector3.Min(screenPosition1, screenPosition2);
        var bottomRight = Vector3.Max(screenPosition1, screenPosition2);

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    Bounds GetViewportBounds(Camera camera, Vector3 screenPositionStart, Vector3 screenPositionEnd)
    {
        var v1 = Camera.main.ScreenToViewportPoint(screenPositionStart);
        var v2 = Camera.main.ScreenToViewportPoint(screenPositionEnd);
        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);

        min.z = camera.nearClipPlane;
        max.z = camera.farClipPlane;

        var bounds = new Bounds();
        bounds.SetMinMax(min, max);

        return bounds;
    }
}
