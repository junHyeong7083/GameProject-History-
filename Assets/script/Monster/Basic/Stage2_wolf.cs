using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Stage2_wolf : MonoBehaviour
{
    string CurrentAnimation = ""; // 현재 어떤 애니메이션이 재생되고 있는지에 대한 변수

    // -------------- Spine Animation --------------
    #region Spine
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;
    //   TrackEntry[] tracks;

    // 현재 애니메이션 처리가 무엇인지 대한 변수
    AnimState_wolf _AnimState;
    #endregion

    public enum AnimState_wolf
    {
        animation,
        run,
    }

    void _AsyncAnimation(AnimationReferenceAsset animClip, bool loop, float timeScalse)
    {
        if (animClip.name.Equals(CurrentAnimation))
            return;

        // 해당 애니메이션으로 변경한다.
        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScalse;

        // 애니메이션이 끝나면 원래 상태로 돌아간다.
        // skeletonAnimation.AnimationState.Complete += delegate { SetCurrentAnimation(AnimState.none); };
        // 현재 재생되고 있는 애니메이션 값을 변경
        CurrentAnimation = animClip.name;

    }

    public void SetTransparencyForAllSlots(float alpha)
    {
        foreach (var slot in skeletonAnimation.Skeleton.Slots)
        {
            Color slotColor = slot.GetColor();
            slotColor.a = alpha;
            slot.SetColor(slotColor);
        }
    }

    public void SetCurrentAnimation(AnimState_wolf _state)
    {
        Debug.Log(_state);

        switch (_state)
        {
            case AnimState_wolf.animation:
                _AsyncAnimation(AnimClip[(int)AnimState_wolf.animation], false, 1f);
                break;
            case AnimState_wolf.run:
                _AsyncAnimation(AnimClip[(int)AnimState_wolf.run], true, 0.7f);
                break;
        }
    }


    void Start()
    {
        if(this != null)
         SetTransparencyForAllSlots(0);
    }

}
