using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float pointx1;
    float pointz1;
    GameObject currentTarget;

    public List<GameObject> PathList;

    public int PathListIndex = 0;

    public float MovementSpeed;
    public float FastSpeed;
    public float currentSpeed;
    public int fastPoint;

    Vector3 MoveDirection;

    public bool HasDynamicDirection;
    public float WithinRange = .75f;
    Transform transf;

    // Start is called before the first frame update
    void Start()
    {
        transf = gameObject.GetComponent<Transform>();
        NextTarget();
        UpdateMovedirection();
        currentSpeed = MovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasDynamicDirection)
        {

            UpdateMovedirection();
        }

        transf.position += (Time.deltaTime * MoveDirection * currentSpeed);

        if (IsCloseToTarget())
        {
            NextTarget();
            UpdateMovedirection();

        }
        if (PathListIndex == fastPoint)
        {
            currentSpeed = FastSpeed;
        }
        if (PathListIndex != fastPoint)
        {
            currentSpeed = MovementSpeed;
        }

    }

    public bool IsCloseToTarget()
    {

        if (GetDistanceTo(currentTarget) < WithinRange)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public float GetDistanceTo(GameObject Other)
    {
        float distanceTo = (Other.transform.position - transform.position).magnitude;
        
        return distanceTo;
    }
    public void NextTarget()
    {
        if (PathListIndex < 2)
        {
            PathListIndex++;
        }
        else
        {
            PathListIndex = 0;
        }
        currentTarget = PathList[PathListIndex];

    }
    public void UpdateMovedirection()
    {


        MoveDirection = (currentTarget.transform.position - transf.position).normalized;


    }
}
