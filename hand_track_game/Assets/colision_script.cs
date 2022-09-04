using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class colision_script : MonoBehaviour
{
    public int Player_health = 100;
    public Animator animator;
  //  public GameObject obj;

    public TMP_Text text;
    public GameObject restart_;
    //->
    // How long the object should shake for.
    public Transform camTransform;
    public float shakeDuration = 0f;
    private GameObject target; 

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float animAmount = 0f;
    //<-
    public GameObject[] itj;
    public int HighSore;
    Vector3 originalPos;

    // Start is called before the first frame update Projectile
    void Start()
    {
        animAmount = 0f;
        target = GameObject.Find("spawner");
        restart_.SetActive(false);
        //dont know why garbage vales 
    }

    // Update is called once per frame
    void Update()
    {
         

        animator.Play("tool", 0, animAmount);
        Debug.Log(animAmount);

        // animator.speed = 0;

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
        if (Player_health <= 0)
        {
            HighSore = target.GetComponent<spawn_players>().totalNumberOfEnemiesKilled;
            string Sore = HighSore.ToString();
            text.text = "High score :" + Sore;

            itj[0].SetActive(false);
            itj[1].SetActive(true);
            restart_.SetActive(true);


        }
       //
	   // Debug.Log(1-(1f / 20) * (Player_health * 2 / 10));
       // animator.Play("tool", 0, ((1f / 20) * (Player_health * 2 / 10)));
        //animator.Play("tool", 0, 0);
    }
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }
    void OnTriggerEnter(Collider cube)
    {
        print("Another object has entered the trigger");
        Player_health -= 10;
        animAmount += 0.1f;

   
       //animator.Play("tool", 0, 1 - ((1f / 20) * (Player_health * 2 / 10)));

        //obj.GetComponent<Animation>()["tool"].time = 5.0f;

        Destroy(cube.gameObject,2f);
        shakeDuration += 0.03f;
    }
}
    

