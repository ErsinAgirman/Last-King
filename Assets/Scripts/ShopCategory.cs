using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;



[CreateAssetMenu(fileName = "ShopCategory", menuName = "ShopSettings/ShopProperty", order = 0)]
public class ShopCategory : ScriptableObject {

  public RowModel rowModel;
    [Serializable]
    public class RowModel{
          
         public List<Rows>  VerticalRows=new List<Rows>();
         public GameObject rowParent;
    }
    
    
}
