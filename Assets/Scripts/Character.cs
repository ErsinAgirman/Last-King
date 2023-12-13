using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rgb2d;
    [SerializeField]private float speed;  
    void Update()
    {
        Movement();
    }
    void Movement()
    {
       float axis=Input.GetAxis("Horizontal");
       rgb2d.velocity=new Vector2(speed*axis,rgb2d.velocity.y);
    }
}
