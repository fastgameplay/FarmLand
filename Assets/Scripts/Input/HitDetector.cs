using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour{
    CameraMovement _cameraMovement;
    [SerializeField] CropScriptable TestCrop;
    

    void Start(){
        _cameraMovement =  Camera.main.GetComponent<CameraMovement>();
    }
    void Update() {  
        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
                
                if (hit.transform.tag == "FarmLand") {  
                    _cameraMovement.TargetTransform = hit.transform;
                    FarmLand farmLand = hit.transform.GetComponent<FarmLand>();
                    if(farmLand.IsCropPlanted) farmLand.Action();
                    else farmLand.Plant(TestCrop);

                    return;
                }  
                _cameraMovement.ResetPosition();
            }  
        }
    }
}
