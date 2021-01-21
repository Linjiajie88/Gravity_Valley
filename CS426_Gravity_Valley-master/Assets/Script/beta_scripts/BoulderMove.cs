using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoulderMove : MonoBehaviour
{

    [SerializeField]
    List<Waypoint> _patrolPoints;

    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null){
            Debug.LogError("Navmesh could not be found : boulder");
        }
        else{
            if(_patrolPoints != null && _patrolPoints.Count >= 2){
                _currentPatrolIndex = 0;
                SetDestination();
            }
        }
    }

    void Update(){
        if ( !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= 2.0f)
        {
            _currentPatrolIndex += 1;
            if(_currentPatrolIndex >= _patrolPoints.Count){
                _currentPatrolIndex = 0;
            }
            SetDestination();
        }
    }

    private void SetDestination(){
        if(_patrolPoints != null){
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
