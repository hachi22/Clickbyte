using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    [SerializeField] Transform startPoint;
    [SerializeField] Transform[] endPoint;
    [SerializeField] Transform[] objectsToMove;

    [SerializeField] PowerUps powerUps;

    [SerializeField] float speed;

    bool up;

   
    public void changeBool()
    {
        if (up)
        {
            up = !up;
        }
        else
        {
            foreach (MoveTowards move in powerUps.listMoveTowards)
            {
                if (move.up)
                {
                    move.up = false;

                }


            }
            up = !up;
        }

    }

    public void HideAll()
    {
        foreach (MoveTowards move in powerUps.listMoveTowards)
        {
            move.up = false;
        }
    }

    private void Update()
    {
        if (!up)
        {
            foreach (Transform transform in objectsToMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed);
            }
      
        }
        else
        {
            if (up)
            {
                for (int i = 0; i < objectsToMove.Length; i++)
                {
                    objectsToMove[i].position = Vector3.MoveTowards(objectsToMove[i].position, endPoint[i].position, speed);

                }
            }

        }
    }



}
