using UnityEngine;
using System.Collections;

public class LightingEffect : MonoBehaviour
{
    public Vector2[] colliderOffsets;  // �� �������� Box Collider offset ��ġ ������ �����ϴ� �迭
    public Vector2[] colliderSizes;    // �� �������� Box Collider size ������ �����ϴ� �迭
     Camera cam;
    Vector3 cameraOriginalPos;
    // ���� �ִϸ��̼��� ������ �ε���
    private int currentFrame = 0;

    // 2D Box Collider ������Ʈ
    private BoxCollider2D collider;

    private void Awake()
    {
        cam = Camera.main;
        cameraOriginalPos = cam.transform.position;

        // Box Collider ������Ʈ �������� (�ش� ���� ������Ʈ�� �̹� �����ؾ� ��)
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // �ִϸ��̼� ������ ����
        UpdateAnimationFrame();

        // Box Collider ������Ƽ ������Ʈ
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

    } // ī�޶� ����ŷ

    public void eventCamera()
    {
        StartCoroutine(CameraShaking(0.3f, 1.3f));
    }

    private void UpdateColliderProperties()
    {
        // ���� �������� offset ��ġ�� size ���� �����ͼ� �ݸ��� ������Ƽ ����
        collider.offset = colliderOffsets[currentFrame];
        collider.size = colliderSizes[currentFrame];
    }

    private void UpdateAnimationFrame()
    {
        // �ִϸ��̼� Ŭ������ ���� �������� �ε����� ������
        Animator animator = GetComponent<Animator>();
        AnimatorStateInfo animatorState = animator.GetCurrentAnimatorStateInfo(0);

        float totalFrames = 8f; // �ִϸ��̼��� ��ü ������ ��
        float normalizedTime = animatorState.normalizedTime % 1f; // ����ȭ�� �ð�(0~1 ����)

        currentFrame = Mathf.FloorToInt(normalizedTime * totalFrames);
    }

}
