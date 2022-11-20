using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CropActionFactory{
    public static CropAction GetAction(CropTypeEnum action, float expiriance, CropEnum type){
        switch (action){
            case CropTypeEnum.Harvestable:
                return new Harvestable(type,expiriance);
            case CropTypeEnum.destructible:
                return new Destroyable(type,expiriance);
            default: return new NonHarvestable(type,expiriance);
        }
    }
}
