using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    Animator anim;

    public GameObject target;

    private bool opened, touching;
    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
        anim.SetBool("Walk_Anim", true);
        opened = false;
        touching = false;
        Invoke("unFreeze", 3.5f);
    }

    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = rot;
        transform.LookAt(target.transform);
        if (opened && touching == false)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 2 * Time.deltaTime);
        }
        else if (touching)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0 * Time.deltaTime);
            anim.SetBool("Walk_Anim", false);
        }
        
    }

    public void unFreeze()
    {
        opened = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("notTouching", 2f);
        }
    }

    public void notTouching()
    {
        touching = false;
        anim.SetBool("Walk_Anim", true);
    }


}
