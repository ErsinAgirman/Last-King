using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GroundWalk : MonoBehaviour
{
    private PhotonView photonView;
    [SerializeField][Header("Movement Property")]private float moveRange,moveSpeed;
    [SerializeField]private LayerMask enemylayer;
    private Transform target,currenttarget;
    private Animator anim;

    private float currentspeed;


    void Start()
    {
        photonView=GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
           gameObject.layer=LayerMask.NameToLayer("Allies");
           currentspeed=moveSpeed;
           currenttarget=GameObject.FindGameObjectWithTag("enemytower").GetComponent<Transform>();
           setTarget=currenttarget;
           anim=GetComponent<Animator>();
        }   
        else
         gameObject.layer=LayerMask.NameToLayer("Enemy");
    }
    public Transform setTarget{
        get{return target;}
        set{target=value;}
    }
    void Update()
    {
        if (photonView.IsMine)
        {
           Movement();
        }
    }
    void Movement()
    {
        anim.SetFloat("isWalking",moveSpeed);
        transform.position=Vector2.MoveTowards(transform.position,new Vector2(target.position.x,transform.position.y),moveSpeed*Time.deltaTime);
      Collider2D[] enemys=Physics2D.OverlapCircleAll(transform.position,moveRange,enemylayer);
       foreach (Collider2D enmy in enemys)
       {
         target=enmy.transform;
         
          Debug.Log(LayerMask.LayerToName(enmy.gameObject.layer));   
       }     
       if (0.1f>Vector2.Distance(transform.position,target.position))
         moveSpeed=0f;
       else
        moveSpeed=currentspeed;
      
        if (GetComponent<PositionControl>().facingright&&transform.position.x>target.position.x||GetComponent<PositionControl>().facingright==false&&transform.position.x<target.position.x)
        {
            GetComponent<PositionControl>().facingright=!GetComponent<PositionControl>().facingright;
            GetComponent<PositionControl>().ChangePosition();
        }
        
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(transform.position,moveRange);
    }
}
