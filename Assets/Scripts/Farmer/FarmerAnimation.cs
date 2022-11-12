using UnityEngine;

public class FarmerAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public float Speed{
        set{
            _animator.SetFloat("Speed",value);
        }
    }
    public void Gathering(){
        Speed = 0;
        _animator.Play("Gathering");
    }
}
