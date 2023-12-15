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
    bool isAttacking;

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
    public float setSpeed{
         get{return currentspeed;}
        set{moveSpeed=value;}
    }
    public bool setAttack{
         get{return isAttacking;}
        set{isAttacking=value;}
    }
    void Update()
    {
        if (photonView.IsMine)
        {
           if(isAttacking==false)
           {
              Movement();
           }
           else
           {
               anim.SetFloat("isWalking",0);
           }
          
        }
    }
    void Movement()
    {
        anim.SetFloat("isWalking",moveSpeed);
      Collider2D[] enemys=Physics2D.OverlapCircleAll(transform.position,moveRange,enemylayer);
       foreach (Collider2D enmy in enemys)
       {
         target=enmy.transform;   
       }     
        if (target == null)
        {
            target =currenttarget;
        }

        if (GetComponent<PositionControl>().facingright&&transform.position.x>target.position.x||GetComponent<PositionControl>().facingright==false&&transform.position.x<target.position.x)
        {
            GetComponent<PositionControl>().facingright=!GetComponent<PositionControl>().facingright;
            GetComponent<PositionControl>().ChangePosition();
        }

        transform.position=Vector2.MoveTowards(transform.position,new Vector2(target.position.x,transform.position.y),moveSpeed*Time.deltaTime);
        
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(transform.position,moveRange);
    }
}
