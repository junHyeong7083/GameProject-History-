using UnityEngine;
using System.Collections;

public class LightingEffect : MonoBehaviour
{
    public Vector2[] colliderOffsets;  // 각 프레임의 Box Collider offset 위치 정보를 저장하는 배열
    public Vector2[] colliderSizes;    // 각 프레임의 Box Collider size 정보를 저장하는 배열
     Camera cam;
    Vector3 cameraOriginalPos;
    // 현재 애니메이션의 프레임 인덱스
    private int currentFrame = 0;

    // 2D Box Collider 컴포넌트
    private BoxCollider2D collider;

    private void Awake()
    {
        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;

        // Box Collider 컴포넌트 가져오기 (해당 게임 오브젝트에 이미 존재해야 함)
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // 애니메이션 프레임 갱신
        UpdateAnimationFrame();

        // Box Collider 프로퍼티 업데이트
        UpdateColliderProperties();
    }

    IEnumerator CameraShaking(float duration, float magnitude)
    {
        float timer = 0;
        while (timer <= duration)
        {
            cam.transform.localPosition = Random.insideUnitSphere * magnitude + cameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = cameraOriginalPos;

    } // 카메라 쉐이킹

    public void eventCamera()
    {
        StartCoroutine(CameraShaking(0.3f, 1.3f));
    }

    private void UpdateColliderProperties()
    {
        // 현재 프레임의 offset 위치와 size 값을 가져와서 콜리더 프로퍼티 갱신
        collider.offset = colliderOffsets[currentFrame];
        collider.size = colliderSizes[currentFrame];
    }

    private void UpdateAnimationFrame()
    {
        // 애니메이션 클립에서 현재 프레임의 인덱스를 가져옴
        Animator animator = GetComponent<Animator>();
        AnimatorStateInfo animatorState = animator.GetCurrentAnimatorStateInfo(0);

        float totalFrames = 8f; // 애니메이션의 전체 프레임 수
        float normalizedTime = animatorState.normalizedTime % 1f; // 정규화된 시간(0~1 범위)

        currentFrame = Mathf.FloorToInt(normalizedTime * totalFrames);
    }

}
