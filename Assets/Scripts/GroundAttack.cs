using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GroundAttack : MonoBehaviour
{
   [SerializeField][Header("Attack Property")]private Transform attackpoint;
   [SerializeField]private float attackspeed,attackrange,damage;
   [SerializeField]private LayerMask enemylayer;
   private PhotonView photonView;
   private Animator anim;
   bool canattack=true;
    void Start()
    {
        photonView=GetComponent<PhotonView>();
        anim=GetComponent<Animator>();
    }

   
    void Update()
    {
        if(photonView.IsMine)
        AttackArea();
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(attackpoint.position,attackrange);
    }
    void AttackArea()
    {
       Collider2D[] enemy=Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemylayer);
       foreach (Collider2D enm in enemy)
       {
         GetComponent<GroundWalk>().setAttack=true;
         if(canattack==true)
         {
            Debug.Log("vurdu");
             enm.GetComponent<PhotonView>().RPC("Hurt", RpcTarget.AllBuffered, damage);
            anim.SetTrigger("attack");
            canattack=false;
            Invoke(nameof(Attackreset),attackspeed);
         }
       }
       if (enemy.Length==0)
       {
            GetComponent<GroundWalk>().setAttack=false;
       }
    }
    void Attackreset()
    {
        canattack=true;
    }
}
