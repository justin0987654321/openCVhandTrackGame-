using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class general_player : MonoBehaviour
{
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
       // target = GameObject.Find("target_");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider cube)
    {

        if (cube.tag == "Projectile")
        {  
            Destroy(this.gameObject);

        }
    }
}
