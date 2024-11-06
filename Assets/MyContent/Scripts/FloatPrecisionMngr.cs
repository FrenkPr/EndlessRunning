using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPrecisionMngr : Singleton<FloatPrecisionMngr>
{
    private List<GameObject> objectsToMove;
    private List<Vector3> objectsToMoveStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        objectsToMove = new List<GameObject>();
        objectsToMoveStartPosition = new List<Vector3>();
    }

    public void Add(GameObject obj, Vector3 startPos)
    {
        if (obj == null)
        {
            return;
        }

        objectsToMove.Add(obj);
        objectsToMoveStartPosition.Add(startPos);
    }

    public void MoveObjectsToOrigin()
    {
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            objectsToMove[i].transform.position -= objectsToMove[i].transform.position;
            objectsToMove[i].transform.position += objectsToMoveStartPosition[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
