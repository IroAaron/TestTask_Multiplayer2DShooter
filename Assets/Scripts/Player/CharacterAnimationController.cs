using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationChanger(GetComponent<CharacterMoving>().GetInputDirection());
    }

    public void AnimationChanger(Vector2 direction)
    {
        switch (direction.x)
        {
            case 0:
                if (direction.y == 0)
                {
                    _animator.SetTrigger("CharacterStopped");
                }
                break;
            case > 0:
                if(direction.y == 0)
                {
                    _animator.Play("MovingSideToSide");
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case < 0:
                if (direction.y == 0)
                {
                    _animator.Play("MovingSideToSide");
                    GetComponent<SpriteRenderer>().flipX = false ;
                }

                break;
            default:
                break;
        }
        switch (direction.y)
        {
            case 0:
                if (direction.x == 0)
                {
                    _animator.SetTrigger("CharacterStopped");
                }
                break;
            case > 0:
                _animator.Play("MovingUp");
                break;
            case < 0:
                _animator.Play("MovingDown");
                break;
            default:
                break;
        }
    }
}
