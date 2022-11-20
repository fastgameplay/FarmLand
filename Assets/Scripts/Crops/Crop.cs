using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop: MonoBehaviour{

    public CropTypeEnum Type{get; private set;}
    CropAction _action;

    public void SetCrop(CropEnum type, float expiriance, CropTypeEnum actionType){
        Type = actionType;
        _action = CropActionFactory.GetAction(actionType, expiriance, type);
    }

    public bool Harvest(){
        return _action.Run();
    }


}
