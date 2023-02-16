using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public spawnData[] spawnDatas;
    public float spawn_Size = 15;
    public float spawn_interval;

    Hashtable corutine_hash;

    
    // Start is called before the first frame update
    void Start()
    {
        corutine_hash = new Hashtable();
        corutine_hash.Add("EnemySpawn",StartCoroutine(EnemySpawn()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 Next_Spawn_Dir(){
        return new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized*spawn_Size;
    }
    IEnumerator EnemySpawn(){
        while(true){
            GameObject spawned_object = GameManager.instance.poolManager.Get(0);

            int level = GameManager.instance.level;

            spawned_object.GetComponent<Enemy>().Init(spawnDatas[level]);

            spawned_object.transform.position = GameManager.instance.player.transform.position +  Next_Spawn_Dir();

            yield return new WaitForSeconds(spawnDatas[level].spawn_interval);
        }
    }
    
}
[System.Serializable]
public class spawnData{
        public int spriteType;
        public float spawn_interval;
        public float health;
        public float speed;
}