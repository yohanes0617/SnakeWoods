﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {
    private Renderer renderer;
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    public Vector2 roringspeed = new Vector2(0.1f, 0.1f);
    //public float speed = 4f; //歩くスピード
    //private Rigidbody2D rigidbody2D;
    private Animator anim;

    void Start()
    {
    //    //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        //    rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //void FixedUpdate()
    //{
    //    float y = Input.GetAxisRaw("Vertical");
    //    //左キー: -1、右キー: 1
    //    float x = Input.GetAxisRaw("Horizontal");
    //    ////左か右を入力したら
    //    if (y != 0)
    //    {
    //        //入力方向へ移動
    //        rigidbody2D.velocity = new Vector2(y * speed, rigidbody2D.velocity.x);
    //        //localScale.xを-1にすると画像が反転するココの処理はxの時だけやね
    //        // Vector2 temp = transform.localScale;
    //        // temp.y = y;
    //        // transform.localScale = temp;
    //        //Wait→Dash
    //        anim.SetBool("down", true);
    //        //左も右も入力していなかったら
    //    }
    //    else if (y == 0)
    //    {
    //        //横移動の速度を0にしてピタッと止まるようにする
    //        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.x);
    //        //Dash→Wait
    //        anim.SetBool("down", false);
    //    }
    //    if (x != 0)
    //    {
    //        //入力方向へ移動
    //        rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
    //        //localScale.xを-1にすると画像が反転する
    //        Vector2 temp = transform.localScale;
    //        temp.x = x;
    //        transform.localScale = temp;

    //        anim.SetBool("side", true);
    //        //左も右も入力していなかったら
    //    }
    //    else if(x==0)
    //    {
    //        //横移動の速度を0にしてピタッと止まるようにする
    //        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    //        //Dash→Wait
    //        anim.SetBool("side", false);
    //    }

    //} 
    void FixedUpdate()
    {
        //回転してる最中にもう一度押せない
        
        Vector2 Position = transform.position;
        
        if (Input.GetKey("left"))
        {
           
            Position.x -= SPEED.x;
            anim.SetBool("left", true);

            if(Input.GetKey("z"))
            {
                anim.SetBool("roring", true);
                Position.x -= roringspeed.x;
                gameObject.layer = LayerMask.NameToLayer("Player_roring");
            }
        }
        else if (Input.GetKey("right"))
        { 
            Position.x += SPEED.x;
            anim.SetBool("right", true);
        }
        else if (Input.GetKey("up"))
        { 
            Position.y += SPEED.y;
            anim.SetBool("up", true);
        }
        else if (Input.GetKey("down"))
        { 
            Position.y -= SPEED.y;
            anim.SetBool("down", true);
        }
        else
        {
            anim.SetBool("up", false);
            anim.SetBool("left", false);
            anim.SetBool("down", false);
            anim.SetBool("right", false);
            anim.SetBool("roring", false);
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }
}
