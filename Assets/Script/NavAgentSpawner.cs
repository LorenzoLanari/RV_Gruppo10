using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _navAgentPrefab;
    [SerializeField] private int _navMeshAgentsToSpawn = 10;
    [SerializeField] private Collider _groundCollider;
    public Transform[] spawns;
    
    public MissionManager manager;
    private int circularBuffer = 0;
    private static NavAgentSpawner _instance;

    public static NavAgentSpawner Instance => _instance;

    void Start()
    {
        _instance = this;
        SpawnNavMeshAgents();
    }

    private void SpawnNavMeshAgents()
    {
        for (int i = 0; i < _navMeshAgentsToSpawn; i++)
        {
            GameObject agent = Instantiate(_navAgentPrefab, GetRandomPositionOnGround(), Quaternion.identity);
            manager.acari.Add(agent);
            foreach (Transform spawn in spawns)
            {              
                agent.GetComponent<AcaroFSM>()._waypoints.Add(spawn.position);               
            }

           // NavMeshAgentRandomPosition targetReached = agent.GetComponent<NavMeshAgentRandomPosition>();
        }
    }

    
    public Vector3 GetRandomPositionOnGround()
    {
        
        return spawns[circularBuffer++].position;
    }

    public void assignWaypoint(GameObject agent, int pos) {
        
    }
}
