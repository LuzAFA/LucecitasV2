using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followers : MonoBehaviour
{
    public float speed;
    public NavMeshAgent agent;
    public Transform pos;
    private Rigidbody rig;
    private Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        agent.SetDestination(pos.position);
        agent.stoppingDistance = Random.Range(1, 3); ;
        agent.speed = Random.Range(2, 5); ;
    }
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(pos.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "salto_1":
                agent.enabled = false;
                rig.isKinematic = false;
                coll.isTrigger = true;
                rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
                rig.AddForce(Vector3.left * (speed / 2), ForceMode.Impulse);
                break;

            case "salto_2":
                agent.enabled = false;
                rig.isKinematic = false;
                coll.isTrigger = true;
                rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
                rig.AddForce(Vector3.right * (speed / 2), ForceMode.Impulse);
                break;
            case "piso":

                agent.enabled = true;
                rig.isKinematic = true;
                break;
            case "destino":
                Debug.Log("llego al personaje ");
                break;

        }
    }

}
