using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_players : MonoBehaviour
{
    public float maxX = 8.45f;
    public float minX = 1.55f;
    public float maxY = 5.88f;
    public float minY = -3.55f;


    public float maxX_1 = 1.43f;
    public float minX_1 = -4.36f;
    public float maxY_1 = 9.02f;
    public float minY_1 = 6.85f;

    public float maxX_2 = 0.27f;
    public float minX_2 = -4.66f;
    public float maxY_2 = -4.26f;
    public float minY_2 = -5.46f;


    public GameObject obj;
    public bool spawned = false;
    public int  NoSpawned =  0;
    int number_tobeSpawned = 20;
    int i = 0; 
    public int totalNumberOfEnemiesKilled = 0;
    public Transform[] transforms;
    public GameObject obj_2;
    bool has_run = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnFunction();
        StartCoroutine(spawnFunction_2());
    }

    // Update is called once per frame
    void Update()
    {
        if (NoSpawned<10) {
            spawnFunction();
            if (totalNumberOfEnemiesKilled < 300)
                number_tobeSpawned += 1;
                
        }



  
    }
    void spawnFunction() {
        while (NoSpawned != number_tobeSpawned)
        {
            Vector3 randompos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0.005f);

            GameObject Enemy = Instantiate(obj, randompos, Quaternion.identity);
            NoSpawned += 1;
        }
    }

    IEnumerator spawnFunction_2()
    {

        while (true) { 
        
            //Vector3 randompos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0.005f);
            yield return new WaitForSeconds(10f);
            Vector3 randompos = new Vector3(Random.Range(minX_1, maxX_1), Random.Range(minY_1, maxY_1), 0.005f);
            Vector3 randompos_2 = new Vector3(Random.Range(minX_2, maxX_2), Random.Range(minY_2, maxY_2), 0.005f);
            GameObject Enemy_1 = Instantiate(obj_2, randompos, Quaternion.identity);
            GameObject Enemy_2 = Instantiate(obj_2, randompos_2, Quaternion.identity);


            //  GameObject Enemy_1 = Instantiate(obj_2, transforms[0].position, Quaternion.identity);
            //GameObject Enemy_2 = Instantiate(obj_2, transforms[1].position, Quaternion.identity);
            yield return new WaitForSeconds(10f);
            has_run = false;
         }




    }
    /* IEnumerator vv() {
          yield return new WaitForSeconds(2.5f);
          spawned = true;
          yield return new WaitForSeconds(4.5f);
          spawned = false;
         // yield return null;
      }
      IEnumerator pp()
      {

          yield return new WaitForSeconds(10.5f);
          spawned = true;

          // yield return null;
      }*/
}
