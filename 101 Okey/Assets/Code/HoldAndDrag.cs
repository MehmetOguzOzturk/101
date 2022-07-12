using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndDrag : MonoBehaviour
{
    float startPosX;
    float startPosY;
    float startPosZ;
    bool isHold;
    GameManager gameManager;

    public delegate void DragEndenDelegete(HoldAndDrag dragableObject);

    public DragEndenDelegete dragEndenCallBack;

  
    void Update()
    {
        if (isHold)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.position.z);
        }


    }

    public void MoveOnX(List<HoldAndDrag> dragObjects)
    {
        foreach (var item in dragObjects)
        {
            if (gameObject != item.gameObject)
            {
                if (transform.position == item.gameObject.transform.position)
                {
                    item.gameObject.transform.position = new Vector3(item.gameObject.transform.position.x + 0.6f, item.gameObject.transform.position.y, item.gameObject.transform.position.z);

                }
            }

        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - gameObject.transform.position.x;
            startPosY = mousePos.y - gameObject.transform.position.y;
            

            isHold = true;

        }
    }

    private void OnMouseUp()
    {
        isHold = false;
        dragEndenCallBack(this);
    }
}
