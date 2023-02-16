using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    bool isLive;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;
    public Rigidbody2D rigid;
    public Collider2D coll;
    public SpriteRenderer sprite;
    public Animator anim;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    void FixedUpdate() {
        //살아있고, 상태가 맞지 않았을때 따라가라
        if(isLive&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) follow_Target();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void follow_Target(){
        Vector2 move_Dir = (target.position - rigid.position).normalized;
        Vector2 next_Vec = move_Dir * speed * Time.fixedDeltaTime;
        sprite.flipX = move_Dir.x<0?true:false;
        rigid.velocity = Vector2.zero;
        transform.Translate(next_Vec);
    }
    void OnEnable() {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        anim.SetBool("Dead",false);
        sprite.sortingOrder = 2;
        health = maxHealth;
    }
    public void Init(spawnData data){
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
        isLive = true;
    }
    void OnTriggerEnter2D(Collider2D other) {
        //불렛 태그랑 닿으면
        if(other.CompareTag("Bullet")){
            health -= other.GetComponent<Bullet>().damage;

            //살았다면
            if(health>0){
            //히트 애니메이션,넉백 구현
                anim.SetTrigger("Hit");
                StartCoroutine(KnocBack());
            }//죽었다면
            else{
                isLive = false;
                coll.enabled = false;
                rigid.simulated = false;
                anim.SetBool("Dead",true);
                sprite.sortingOrder--;
            }
        }
    }
    void Dead(){
        gameObject.SetActive(false);
    }
    IEnumerator KnocBack(){
        yield return new WaitForFixedUpdate();
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 knocDir = transform.position - playerPos;
        rigid.AddForce(knocDir.normalized*5,ForceMode2D.Impulse);
    }
}
