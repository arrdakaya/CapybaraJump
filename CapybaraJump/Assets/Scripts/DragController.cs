using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool isDrag = false;
    private Vector2 screenPos;
    private Vector3 worldPos;
    private DragDrop lastDragged;
    public bool isShouldMove;
    public DragDrop LastDragged => lastDragged;

    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }

    }
    void Update()
    {
       

        
        if(isDrag && (Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            endDrag();
            return;
        }
        if(Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        
        if (isDrag)
        {
             Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null)
            {
                DragDrop dragDrop = hit.transform.gameObject.GetComponent<DragDrop>();
                if (dragDrop !=null)
                {
                    lastDragged = dragDrop;
                    initDrag();
                }
            }
        }
    }
    void initDrag()
    {
        lastDragged.lastPos = lastDragged.transform.position;
        UpdateDragStatus(true);
    }
    void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPos.x, worldPos.y);
    }
    void endDrag() 
    {
        UpdateDragStatus(false);
    }
    void UpdateDragStatus(bool isDragging)
    {
        isDrag = lastDragged.isDragging = isDragging;
        lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }
    
}
