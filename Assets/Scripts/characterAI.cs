using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class characterAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public float checkRate = 0.5f;
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= checkRate)
        {
            agent.SetDestination(player.instance.transform.position);
            count = 0;
        }
        else
        {
            count += Time.deltaTime;
        }
    }
}
