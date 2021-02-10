using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private bool rightItem = false;

    public int Id;
    private void Update()
    {
        if (Id != 0)
        {
            if (transform.childCount > 0)
            {
                if (GetComponentInChildren<DragHandler>().Id == Id)
                {
                    rightItem = true;
                }
                else
                    rightItem = false;

               
            }
        }
    }

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public bool RightItem() {
        return rightItem;
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
           // ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
    }
    #endregion
}