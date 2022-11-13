using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool IsActive{get; private set;}
    [SerializeField] GameObject _plantPanel;
    [SerializeField] GameObject _harvestPanel;
    [SerializeField] FarmerMovement _farmerMovement;
    FarmLand _farmland;
    public void OnFarmClick(FarmLand farmland){
        _farmland = farmland;
        activatePanel(farmland.IsCropPlanted);
        IsActive = true;
    }
    

    public void CloseAllPanels(){
        _harvestPanel.SetActive(false);
        _plantPanel.SetActive(false);
        IsActive = false;
        _farmland = null;
    }
    
    public void addDestination( EFarmerActionType action, CropScriptable crop){
        _farmerMovement.AddDestination(new FarmerDestination(_farmland,action,crop));
        CloseAllPanels();
    }
    
    void activatePanel(bool IsCropPlanted){
            _harvestPanel.SetActive(IsCropPlanted);
            _plantPanel.SetActive(!IsCropPlanted);
    }
}
