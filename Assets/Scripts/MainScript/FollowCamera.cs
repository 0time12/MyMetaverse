using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothSpeed = 5f;

    [SerializeField]
    private TilemapCollider2D tilemapCollider;

    public Vector3 offset = new Vector3(0, 0, -10);
    private Vector2 minPosition;
    private Vector2 maxPosition;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        if (tilemapCollider != null)
        {
            SetBoundsFromTilemap();
        }
        else
        {
            Debug.LogWarning("[FollowCamera] TilemapCollider2D�� �������� �ʾҽ��ϴ�. ���� min/max�� �Է��ϰų� tilemapCollider�� �����ϼ���.");
        }
    }
    void LateUpdate()
    {
        if (target == null) return;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // ī�޶� ũ�� ���
        float clampedX = Mathf.Clamp(smoothedPosition.x, minPosition.x + halfWidth, maxPosition.x - halfWidth);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minPosition.y + halfHeight, maxPosition.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
    }


    public void SetBoundsFromTilemap()
    {
        Bounds bounds = tilemapCollider.bounds;
        minPosition = bounds.min;
        maxPosition = bounds.max;
    }

    // ��� Ȯ�ο�
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = (minPosition + maxPosition) * 0.5f;
        Vector3 size = new Vector3(maxPosition.x - minPosition.x, maxPosition.y - minPosition.y, 0f);
        Gizmos.DrawWireCube(center, size);
    }
}