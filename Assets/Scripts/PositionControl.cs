
using UnityEngine;

public class PositionControl : MonoBehaviour
{
    public bool facingright;
    public void ChangePosition()
    {
        transform.localScale=
        new Vector2(transform.localScale.x*-1,transform.localScale.y);
    }
}
