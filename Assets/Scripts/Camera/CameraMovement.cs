using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    public Transform TargetTransform{
        set{
            StopAllCoroutines();
            StartCoroutine(Transition(value.position + _offset));
        }
    }

    [SerializeField] float _transitionDuration;
    [SerializeField] Vector3 _offset;
    Vector3 _initialPosition;
    Quaternion _initialRotation;
    void Start(){
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }

    public void ResetPosition(){
        StopAllCoroutines();
        StartCoroutine(Transition(_initialPosition));
    }
    
    IEnumerator Transition(Vector3 targetPos){
        float percent = 0f;
        Vector3 startPos = transform.position;
        while(percent < 1.0f){
            percent += Time.deltaTime + (Time.timeScale/_transitionDuration);

            transform.position = Vector3.Lerp(startPos,targetPos,percent);

            yield return 0;
        }
    }


}
