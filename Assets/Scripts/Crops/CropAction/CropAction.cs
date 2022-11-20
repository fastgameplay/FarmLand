public abstract class CropAction
{
    protected CropEnum _cropType;
    protected float _exp;
    public CropAction(CropEnum type, float exp){
        _cropType = type;
        _exp = exp;
    }
    public abstract bool Run();
}