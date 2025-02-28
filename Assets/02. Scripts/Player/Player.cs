using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    BoxCollider2D _collider;
    SpriteRenderer _spriteRenderer;
    

    public float jumpPower;
    public float forwardSpeed;
    public bool isDead = false;

    public int jumpCount = 0;
    public int maxJump = 2; // 최대 점프 2회 제한
    public float slideDuration = 1f; // 슬라이딩 지속시간
    public int health;

    bool isSliding = false;
    bool isFlap = false;
    private float damageCooldown = 1f; // 데미지를 받을 간격


    private Vector2 originalColliderSize; // 원래의 콜라이더 크기
    private Vector2 originalColliderOffset; // 원래의 콜라이더 위치

    Vector3 originalScale;  // 원래의 스케일을 저장할 변수

    private float lastDamageTime = 0f;
    GameManager gameManager;
    Animator animator;

    private static readonly int IsJumping = Animator.StringToHash("IsJump");
    private static readonly int IsSliding = Animator.StringToHash("IsSlide");
    void Start()
    {
        gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


        // 원래의 콜라이더 크기 저장
        originalColliderSize = _collider.size;
        originalColliderOffset = _collider.offset;

        // 원래의 스케일 저장
        originalScale = transform.localScale;

       
    }

    void Update()
    {
        forwardSpeed = gameManager.GetSpeedFromGM();
        health = gameManager.GetHealthFromGM();

        if (Input.GetKeyDown(KeyCode.Space) && !isSliding && jumpCount < maxJump)
        {
            isFlap = true;
            jumpCount++;
            animator.SetBool(IsJumping, true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && jumpCount == 0) // 공중에서는 슬라이드 불가
        {
            StartCoroutine(Slide());
            transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool(IsSliding, true);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y = jumpPower;
            isFlap = false;
        }

        _rigidbody.velocity = velocity; 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // 바닥에 닿으면 점프 횟수 초기화
            animator.SetBool(IsJumping, false);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (Time.time - lastDamageTime > damageCooldown)
                {
                    gameManager.CollisionObstacle();
                    lastDamageTime = Time.time;
                    StartCoroutine(Collide());
                }
        }
    }

    IEnumerator Collide()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color newColor = sr.color;
        newColor.a = 0.5f;
        sr.color = newColor;
        yield return new WaitForSeconds(damageCooldown);
        newColor.a = 1f;
        sr.color = newColor;
    }


    IEnumerator Slide()
    {
        isSliding = true;

        // 콜라이더 크기 줄이기 (슬라이딩 효과)
        _collider.size = new Vector2(originalColliderSize.x , originalColliderSize.y / 2);
        _collider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y / 8));

        
        yield return new WaitForSeconds(slideDuration); // 일정 시간 후 해제

        // 원래 크기로 복귀
        _collider.size = originalColliderSize;
        _collider.offset = originalColliderOffset;

        

        // 원래 스케일로 복구
        transform.localScale = originalScale;

        isSliding = false;

        animator.SetBool(IsSliding, false);
    }

}
