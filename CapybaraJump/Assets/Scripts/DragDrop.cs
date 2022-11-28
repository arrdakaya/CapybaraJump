using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool isCheck;
    public bool isDragging;
    public Vector3 lastPos;
    private Collider2D _collider;
    private DragController dragController;
    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        dragController = GetComponent<DragController>();  
    }
    private void FixedUpdate()
    {
        if (isCheck)
        {

       
            if (movementDestination.HasValue)
            {
           
                if (isDragging)
                {
                    movementDestination = null;
                    return;
                }
            
                if (transform.position == movementDestination)
                {
                    gameObject.layer = Layer.Default;
                    movementDestination = null;
                }
            
               
                else
                {
                    transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
                }
            
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
  
        if (collision.CompareTag("Slot"))
        {
            movementDestination = collision.transform.position;
        }
        else if (collision.CompareTag("NotValid"))
        {
            movementDestination = lastPos;
        }
    }
}
