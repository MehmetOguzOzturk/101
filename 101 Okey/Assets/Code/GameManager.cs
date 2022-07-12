using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<HoldAndDrag> dragAbleObjects;
    public List<Transform> snapPoints;
    public float snapRange = 0.5f;
    void Start()
    {
        foreach (HoldAndDrag dragable in dragAbleObjects)
        {
            dragable.dragEndenCallBack = OnDragEnded;
        }
    }

   void OnDragEnded(HoldAndDrag dragable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPos in snapPoints)
        {
            float currenDistance = Vector2.Distance(dragable.transform.localPosition, snapPos.transform.localPosition);

            if (closestSnapPoint==null || currenDistance<closestDistance)
            {
                closestSnapPoint = snapPos;
                closestDistance = currenDistance;
                            
            }
        }

        if (closestSnapPoint!=null && closestDistance<=snapRange)
        {
            dragable.transform.localPosition = closestSnapPoint.localPosition;
            dragable.MoveOnX(dragAbleObjects);

        }

        
    }
}
