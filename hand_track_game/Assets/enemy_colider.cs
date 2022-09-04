using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_colider : MonoBehaviour
{
    private GameObject target;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("spawner");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerEnter(Collider cube)
    {
      if (cube.tag == "Projectile") {

            Debug.Log("hit");
            target.GetComponent<spawn_players>().totalNumberOfEnemiesKilled += 1;
            target.GetComponent<spawn_players>().NoSpawned -= 1;
            obj.SetActive(true);
            Destroy(this.gameObject,0.2f);

        }
    }
}
