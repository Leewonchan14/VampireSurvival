using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;
    Rigidbody2D rigid;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();    
    }

    public void Init(float damage,int per,Vector2 dir){
        this.damage = damage;
        this.per = per;
        //원거리 무기인 녀석들
        if(per> -1){
            rigid.velocity = dir;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        //원거리무기가 적과 부딪혔을때 관통-- , 속도초기화, 비활성화
        if(other.gameObject.CompareTag("Enemy")&&per>-1){
            per--;
            if(per == -1){
                rigid.velocity = Vector2.zero;
                gameObject.SetActive(false);
            }
        }        
    }
}
