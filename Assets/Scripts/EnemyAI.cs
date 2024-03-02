using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _NavMeshAgent;
    private bool _isPlayerNoticed;

    void Start()
    {
        Links();

        ChooseNewPosition();
    }

    void Links()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        UpdatePos();
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        RaycastHit hit;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    void ChooseNewPosition()
    {
        _NavMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    void UpdatePos()
    {
        if (!_isPlayerNoticed)
        {
            if (_NavMeshAgent.remainingDistance == 0)
            {
                ChooseNewPosition();
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _NavMeshAgent.destination = player.transform.position;
        }
    }
}
