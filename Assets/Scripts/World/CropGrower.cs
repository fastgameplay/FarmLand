using System.Collections;
using UnityEngine;

public class CropGrower : MonoBehaviour{
    public float Progress { 
        get{return _progress;} 
        
        private set{
            _progress = value;
            _cropObject.transform.localScale = Vector3.Lerp(_startScale,_finalScale,value);
        } 
    }
    private float _progress;
    GameObject _cropObject;
    Vector3 _finalScale = Vector3.one;
    Vector3 _startScale = Vector3.zero;



    public void DestoryCrop(){
        if(_cropObject != null){
            StopAllCoroutines();
            Destroy(_cropObject);
        }
    }
    public void PlantCrop(CropScriptable crop){
        _cropObject = Instantiate(crop.Prefab, transform.position, Quaternion.identity, transform);
        _finalScale = _cropObject.transform.localScale;
        StartCoroutine(IEGrowCrop(crop.GrowthDuration));
    }

    IEnumerator IEGrowCrop(float time){
        Progress = 0;
        float rate = 1 / time;

        while(Progress < 1){
            Progress += Time.deltaTime * rate;
            yield return 0;
        }
        Progress = 1;

    }   
}
