using UnityEngine;

public class LightingEffect : MonoBehaviour
{
    public Vector2[] colliderOffsets;  // �� �������� Box Collider offset ��ġ ������ �����ϴ� �迭
    public Vector2[] colliderSizes;    // �� �������� Box Collider size ������ �����ϴ� �迭

    // ���� �ִϸ��̼��� ������ �ε���
    private int currentFrame = 0;

    // 2D Box Collider ������Ʈ
    private BoxCollider2D collider;

    private void Awake()
    {
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
