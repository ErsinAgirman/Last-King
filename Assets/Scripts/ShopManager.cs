using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]private ShopCategory shopCategory;
    [SerializeField]private Transform verticalroot;
    void Start()
    {
        SetRows(verticalroot.transform);
    
    }
    public void SetRows(Transform root)
    {
        List<Rows> rows=shopCategory.rowModel.VerticalRows;
        for (int i = 0; i < rows.Count; i++)
        {
            rows[i].rowborder.transform.parent=root.parent;
        }
     
        
    }
}
