using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    EntityTypes entityTypes;

    public List<GameObject> Entities;
    public List<GameObject> Units;


    // COMPONENT
    // ==================================================================================

    void Start ()
    {
        entityTypes = GetComponent<EntityTypes>();

        Debug.Assert(entityTypes != null, "Null entityTypes");

        Entities = new List<GameObject>();
        Units = new List<GameObject>();
    }
	
	void Update ()
    {

    }


    // PUBLIC
    // ==================================================================================

    public void SpawnUnit(Vector3 position)
    {
        GameObject entity = Instantiate(entityTypes.Generic, this.transform);

        entity.transform.position = position;

        Entities.Add(entity);
        Units.Add(entity);
    }
}
