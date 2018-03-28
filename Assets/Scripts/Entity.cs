using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool IsSelected;

    GameObject selectionSprite;

	void Start ()
	{
        selectionSprite = transform.Find("Selection").gameObject;

        Debug.Assert(selectionSprite != null, "Null selection");

        selectionSprite.SetActive(false);
	}
	
	void Update ()
	{
		
	}

    public void Select()
    {
        selectionSprite.SetActive(true);
        IsSelected = true;
    }

    public void Deselect()
    {
        selectionSprite.SetActive(false);
        IsSelected = false;
    }
}
