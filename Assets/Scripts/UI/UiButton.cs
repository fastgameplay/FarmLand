using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UiButton : MonoBehaviour{
    [SerializeField] UIManager _panelManager;
    [SerializeField]  EFarmerActionType _action;
    [SerializeField] CropScriptable _crop;

    public void OnClick(){
        _panelManager.addDestination(_action,_crop);
    }
}
