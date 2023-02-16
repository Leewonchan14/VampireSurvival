using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int id;
    public int prefab_id;
    public float damage;
    public int count;
    public float speed;

    player player;
    float timer = 0;

    void Awake() {
        player = GetComponentInParent<player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            LevelUp(2,2);
        }
        switch(id){
            case 0:{
                transform.Rotate(Vector3.back*speed*Time.deltaTime);
                break;
            }
            case 1: {
                timer += Time.deltaTime;
                if(timer>speed){
                    fire();
                    timer = 0;
                }
                break;
            }
            default : break;
        }
    }
    public void Init(){
        switch(id){
            case 0:{
                speed = 150;
                Batch();
                break;
            }
            case 1: {
                speed = 0.3f;
                break;
            }
        }
    }
    //근접무기
    public void Batch(){
        float rotate_interval = 360/count;
        for(int index = 0;index<count;index++){
            Transform spawned_transform;
            if(index < transform.childCount){
                spawned_transform = transform.GetChild(index);
                spawned_transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            else{
                spawned_transform = GameManager.instance.poolManager.Get(prefab_id).transform;
            }
            spawned_transform.parent = transform;
            spawned_transform.position = GameManager.instance.player.transform.position;
            spawned_transform.Rotate(0,0,rotate_interval*index);
            spawned_transform.position += spawned_transform.up * 1.5f;
            spawned_transform.GetComponent<Bullet>().Init(damage,-1,Vector2.zero); // -1 is infinity Per;
        }
    }
    
    //원거리 무기
    public void fire(){
        if(player.scan.nearestTarget == null) return;
        Vector3 targetPos = player.scan.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;

        dir = dir.normalized;
        
        Transform bullet = GameManager.instance.poolManager.Get(prefab_id).transform;
        bullet.position = transform.position;

        bullet.rotation = Quaternion.FromToRotation(Vector3.up,dir);

        bullet.GetComponent<Bullet>().Init(damage,count,dir*15);
    }

    public void LevelUp(float damage,int count){
        this.damage += damage;
        this.count += count;
        if(id == 0){
            Batch();
        }
    }
}
