using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject player;
    private NavMeshAgent navMeshAgent;
    private float eSpeed;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        eSpeed = navMeshAgent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.position;
        CheckFreezeTime();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void CheckFreezeTime()
    {

        if (player.GetComponent<InputManager>().inFreezeTime)
        {
            navMeshAgent.speed = 0;
        }
        if (!player.GetComponent<InputManager>().inFreezeTime)
        {
            navMeshAgent.speed = eSpeed;
        }
    }
}
