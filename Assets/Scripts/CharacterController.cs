using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    NavMeshAgent agent;
    Camera camera;
    Entity entity;

    void Start ()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        entity = GetComponent<Entity>();
    }
	
	void Update ()
    {
        if(entity.IsSelected)
        { 
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;

                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }
    }
}
