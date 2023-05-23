using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class MatchItem : MonoBehaviour, IPointerDownHandler,IDragHandler, IPointerEnterHandler, IPointerUpHandler // interfaces
{
    static MatchItem hoverItem;

    public GameObject linePrefab;
    public string  itemName;

    private GameObject line;

  


    public void OnPointerDown(PointerEventData eventData)
    {
        line = Instantiate(linePrefab, transform.position, Quaternion.identity, transform.parent.parent);
        UpdateLine(eventData.position);


        Debug.Log(transform.position);
       // throw new System.NotImplementedException();
    }
    public void OnDrag(PointerEventData eventData)
    {
        UpdateLine(eventData.position);
        //throw new System.NotImplementedException();
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!this.Equals(hoverItem) && itemName.Equals(hoverItem.itemName))
        {
            UpdateLine(hoverItem.transform.position);
            Destroy(hoverItem);
            Destroy(this);
            MatchLogic.AddPoint();

        }
        else
        {
            Destroy(line); 
        }
        //  throw new System.NotImplementedException();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverItem = this; 
        // throw new System.NotImplementedException();
    }

    void UpdateLine(Vector3 position)
    {
        //update direction
        Vector3 direction = position - transform.position;
        line.transform.right = direction;

        //update scale
        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }
}
