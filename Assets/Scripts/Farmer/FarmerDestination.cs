using UnityEngine;
public struct FarmerDestination{
    public FarmLand FarmLand;
    public EFarmerActionType Action;
    public CropScriptable Crop;
    public Vector3 Destination{get {return FarmLand.transform.position;}}
    public FarmerDestination(FarmLand farmLand, EFarmerActionType action){
        FarmLand = farmLand;
        Action = action; 

        Crop = null;
    }
    public FarmerDestination(FarmLand farmLand, EFarmerActionType action, CropScriptable crop){
        FarmLand = farmLand;
        Action = action; 

        Crop = crop;
    }
    public void DoAction(){
        switch(Action){
            case EFarmerActionType.Plant:
                FarmLand.Plant(Crop);
            break;

            case EFarmerActionType.Gather:
                FarmLand.Harvest();
            break;
        }
    }



}