using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Rows", menuName = "ShopSettings/Rows", order = 0)]
public class Rows : ScriptableObject {
    public Image rowimage;
    public string rowname;
    public GameObject rowborder;
}


