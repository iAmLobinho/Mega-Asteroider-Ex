using UnityEngine;

//TODO: Improve Set Animator
namespace SABI
{
    public static class AnimatorExtensions
    {
        // public static Animator SetAnimation(
        //     this Animator animator,
        //     string animationStateName,
        //     // bool canPlaySameAnimation = false,
        //     int layer = 0,
        //     float transitionDuration = 0.2f
        // )
        // {
        //     {
        //         animator.CrossFade(animationStateName, transitionDuration, layer);
        //         // currentAnimationStates[layer] = animationStateName;
        //     }
        //     return animator;
        // }

        // public static Animator PlayAnimation(
        //     this Animator animator,
        //     string animationStateName,
        //     int layer = 0
        // )
        // {
        //     animator.Play(animationStateName, layer);
        //     return animator;
        // }

        public static Animator PauseAnimations(this Animator animator)
        {
            animator.speed = 0f;
            return animator;
        }

        public static Animator ResumeAnimations(this Animator animator)
        {
            animator.speed = 1f;
            return animator;
        }
    }
}
