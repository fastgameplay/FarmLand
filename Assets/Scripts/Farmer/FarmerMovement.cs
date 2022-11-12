using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(FarmerAnimation))]
[RequireComponent(typeof(NavMeshAgent))]
public class FarmerMovement : MonoBehaviour
{
    [SerializeField] float _PlantingDuration;
    List<FarmerDestination> targetPoints = new List<FarmerDestination>(); 

    FarmerAnimation _customAnimator;
    NavMeshAgent _agent;
    bool _isMoving;
    void Awake(){
        _customAnimator = GetComponent<FarmerAnimation>();
        _agent = GetComponent<NavMeshAgent>();
        _isMoving = false;
    }        

    public void AddDestination(FarmerDestination farmerDestination){
        targetPoints.Add(farmerDestination);
        if(_isMoving == false){
            StartCoroutine(MoveToTargetPoints());
        }
    }

    IEnumerator MoveToTargetPoints(){
        _isMoving = true;
        while(targetPoints.Count >0){
            _agent.destination = targetPoints[0].Destination;
            _customAnimator.Speed = 1;
            yield return StartCoroutine(WaitUntillNear());
            _customAnimator.Gathering();
            yield return new WaitForSeconds(_PlantingDuration);
            targetPoints[0].DoAction();
            targetPoints.RemoveAt(0);
        }
        _isMoving = false;
    }

    IEnumerator WaitUntillNear(){
        while(Vector3.Distance(transform.position,targetPoints[0].Destination) > 0.1f){
                yield return 0;
        }
    }
}
