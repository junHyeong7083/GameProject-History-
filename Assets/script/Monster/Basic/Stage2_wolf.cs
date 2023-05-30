using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class Stage2_wolf : MonoBehaviour
{
    string CurrentAnimation = ""; // ���� � �ִϸ��̼��� ����ǰ� �ִ����� ���� ����

    // -------------- Spine Animation --------------
    #region Spine
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;
    //   TrackEntry[] tracks;

    // ���� �ִϸ��̼� ó���� �������� ���� ����
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

        // �ش� �ִϸ��̼����� �����Ѵ�.
        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScalse;

        // �ִϸ��̼��� ������ ���� ���·� ���ư���.
        // skeletonAnimation.AnimationState.Complete += delegate { SetCurrentAnimation(AnimState.none); };
        // ���� ����ǰ� �ִ� �ִϸ��̼� ���� ����
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
