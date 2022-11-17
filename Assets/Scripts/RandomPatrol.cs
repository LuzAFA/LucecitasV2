using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public float speed;
    public float dir;
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
        agent.speed = Random.Range(5, 20);
        agent.stoppingDistance = Random.Range(1, 3); ;

        InvokeRepeating("cambioAleatorioDestino", 5, 5);

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(pos.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("salto_1"))
        {
            Debug.Log("salto 1");
            agent.enabled = false;
            rig.isKinematic = false;
            coll.isTrigger = true;
            rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
            rig.AddForce(Vector3.left * (speed / 2), ForceMode.Impulse);
        }
        if (other.CompareTag("salto_2"))
        {
            Debug.Log("salto 222222222222222");
            agent.enabled = false;
            rig.isKinematic = false;
            coll.isTrigger = true;
            rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
            rig.AddForce(Vector3.right * (speed / 2), ForceMode.Impulse);
        }
        if (other.CompareTag("piso"))
        {
            Debug.Log("piso");
            agent.enabled = true;
            rig.isKinematic = true;
            //rig.AddForce(Vector3.up * speed, ForceMode.Impulse);
            //rig.AddForce(new Vector3(-1, 0, 0) * (speed / 2), ForceMode.Impulse);
        }
        if (other.CompareTag("destino"))
        {
            Invoke("cambioAleatorioDestino", 0.1f);
            Debug.Log("llego al destino " + pos.position);
        }

    }

    private void cambioAleatorioDestino()
    {
        int newX = Random.Range(-72, 114);
        int newZ = Random.Range(-56, 37);
        pos.position = new Vector3(newX, pos.position.y, newZ);
        //agent.SetDestination(pos.position);
    }
}
