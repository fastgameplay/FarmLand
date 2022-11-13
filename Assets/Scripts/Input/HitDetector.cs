using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 public class HitDetector : MonoBehaviour{
    [SerializeField] UIManager _panelManager;
    CameraMovement _cameraMovement;
    void Start(){
        _cameraMovement =  Camera.main.GetComponent<CameraMovement>();


    }
    void Update() {  
        if (Input.GetMouseButtonDown(0)) {  
            if(_panelManager.IsActive) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
                
                if (hit.transform.tag == "FarmLand") {  
                    _cameraMovement.TargetTransform = hit.transform;
                    FarmLand farmLand = hit.transform.GetComponent<FarmLand>();
                    if(farmLand.CropType == CropTypeEnum.NonHarvestable) return;
                    
                    _panelManager.OnFarmClick(farmLand);
                    
                    // if(farmLand.IsCropPlanted) farmerMovement.AddDestination(new FarmerDestination(farmLand,EFarmerActionType.Gather));
                    // else farmerMovement.AddDestination(new FarmerDestination(farmLand,EFarmerActionType.Plant,TestCrop));

                    return;
                }  
                _panelManager.CloseAllPanels();
                _cameraMovement.ResetPosition();
            }  
        }
    }
}
