using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    EntityController entities;


    // COMPONENT
    // ==================================================================================

	void Start ()
    {
        entities = GetComponent<EntityController>();

        Debug.Assert(entities != null, "Null entities.");
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                entities.SpawnUnit(hit.point);
            }
        }
    }


    // PUBLIC
    // ==================================================================================




    // PRIVATE
    // ==================================================================================
}
