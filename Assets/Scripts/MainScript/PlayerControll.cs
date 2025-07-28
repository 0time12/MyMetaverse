using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection = Vector2.right; // 기본값 오른쪽
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        // 이동 중이면 마지막 방향 저장
        if (moveDirection.magnitude > 0.01f)
        {
            lastMoveDirection = moveDirection;
        }

        // 애니메이션
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        animator.SetBool("IsMoving", moveDirection.magnitude > 0.01f);
        animator.SetFloat("LastMoveX", lastMoveDirection.x);

        // flip 처리 (X값만)
        if (lastMoveDirection.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(lastMoveDirection.x);
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}