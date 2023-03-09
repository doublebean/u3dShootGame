using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryList<T> where T : class //对泛型进行约束,只能接受类作为参数类型
{
    private T _item;
    public T item
    {
        get { return _item; }
        set { _item = value; }
    }

    public InventoryList()
    {
        Debug.Log("泛型 Generic list initalized...");
    }
    
    public void SetItem(T newItem)
    {
        _item = newItem;
        Debug.Log("New item add....");
    }
}

