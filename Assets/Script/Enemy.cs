using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;           // có thể gán trong Inspector hoặc tag Player = "Player"
    public float updateRate = 0.2f;    // cập nhật đường đi mỗi 0.2s

    NavMeshAgent agent;
    float nextUpdate;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
        }
    }

    void Update()
    {
        if (agent == null || player == null) return;

        if (Time.time >= nextUpdate)
        {
            agent.SetDestination(player.position);
            nextUpdate = Time.time + updateRate;
        }
    }
}
