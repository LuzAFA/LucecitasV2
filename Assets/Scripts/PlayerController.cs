using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent player;
    Vector3 newPosition;
    public Transform leftDoor;
    public Transform rigthDoor;

    private void Start()
    {
        player = GetComponent<NavMeshAgent>(); 
        newPosition = transform.position;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                player.SetDestination(newPosition);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("uwu");
        if (collision.gameObject.CompareTag("key"))
        {
            Debug.Log("toco la llave");
            leftDoor.Rotate(0, 90, 0); 
            rigthDoor.Rotate(0, -90, 0);
            Destroy(collision.gameObject);
        }


    }
}
