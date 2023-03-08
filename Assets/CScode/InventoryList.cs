using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryList<T>
{
    private T _item;
    public T item
    {
        get { return _item; }
        set { _item = value; }
    }

    public InventoryList()
    {
        Debug.Log("·ºÐÍ Generic list initalized...");
    }
    
    public void SetItem(T newItem)
    {
        _item = newItem;
        Debug.Log("New item add....");
    }
}

