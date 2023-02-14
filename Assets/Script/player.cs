using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
public class player : MonoBehaviour
{
    public Vector2 inputVec;
    public float Move_Speed;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec*Move_Speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position+nextVec);
    }
    void OnMove(InputValue value){
        inputVec = value.Get<Vector2>();
    }
    void LateUpdate() {
        anim.SetFloat("Speed",inputVec.magnitude);
        // 0이 아닐때 방향을 바꿔줌
        if(inputVec.x!=0){
            sprite.flipX = inputVec.x<0;
        }
    }
}
