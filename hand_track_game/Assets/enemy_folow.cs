using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_folow : MonoBehaviour
{
    // Start is called before the first frame update
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    private GameObject target;

    void Awake()
    {
        target = GameObject.Find("cuute (1)");
    }


    void Update()
    {

        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);


    }
}
