using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control_script : MonoBehaviour
{
    // Start is called before the first frame update

  
    public Transform target;
    public  Vector3 v_diff;
    private float atan2;
    public Transform rot;
    //
    public GameObject obj;
    //
    /*[SerializeField]
    public float CharacterSpeed = 1.0f;
    private Vector2 InputDir;
    public Rigidbody PlayerPhysics;*/

    void Start()
    {

    }

    void Awake()
    {

        //PlayerPhysics = GetComponent<Rigidbody>();

    }

    void Update()
    {

        //transform.LookAt(target);
        
        v_diff = (target.position - transform.position);
        // Debug.Log(v_diff);
        //----//----//

        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        rot.rotation  = Quaternion.Euler(0f, 0f, 20 * atan2 * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0f, 0f, 20*atan2 * Mathf.Rad2Deg);

        //----//----//-----//


    }
  
    void FixedUpdate()
    {
        /*
        InputDir = new Vector2(v_diff.y, v_diff.x).normalized;
        Vector2 WhereAmI = PlayerPhysics.position;
        Vector2 WhereTo = WhereAmI + (InputDir * CharacterSpeed) * Time.fixedDeltaTime;
        PlayerPhysics.MovePosition(WhereTo);
        */

    }

}
