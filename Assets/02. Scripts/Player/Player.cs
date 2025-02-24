using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    BoxCollider2D _collider;
    SpriteRenderer _spriteRenderer;
    

    public float jumpPower;
    public float forwardSpeed;
    public bool isDead = false;
    float DeathCooldonw = 0f;
    public int jumpCount = 0;
    public int maxJump = 2; // 최대 점프 2회 제한
    public float slideDuration = 1f; // 슬라이딩 지속시간
    public int health;

    bool isSliding = false;
    bool isFlap = false;
    private Vector2 originalColliderSize; // 원래의 콜라이더 크기
    private Vector2 originalColliderOffset; // 원래의 콜라이더 위치

    Vector3 originalScale;  // 원래의 스케일을 저장할 변수

    public Sprite normalSprite;  // 원래 스프라이트
    public Sprite slideSprite;   // 슬라이드할 때의 스프라이트
    public Sprite jumpSprite;   // 점프할 때의 스프라이트
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();


        // 원래의 콜라이더 크기 저장
        originalColliderSize = _collider.size;
        originalColliderOffset = _collider.offset;

        // 원래의 스케일 저장
        originalScale = transform.localScale;

        // 원래의 스프라이트 저장
        _spriteRenderer.sprite = normalSprite;
    }

    void Update()
    {
        forwardSpeed = gameManager.GetSpeedFromGM();
        health = gameManager.GetHealthFromGM();

        if (Input.GetKeyDown(KeyCode.Space) && !isSliding && jumpCount < maxJump)
        {
            isFlap = true;
            jumpCount++;
            _spriteRenderer.sprite = jumpSprite;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && jumpCount == 0) // 공중에서는 슬라이드 불가
        {
            StartCoroutine(Slide());
            transform.localScale = new Vector3(3.5f, 1f, 1);
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
            _spriteRenderer.sprite = normalSprite; // 원래 스프라이트로 복구

        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.CollisionObstacle(); // 장애물 충돌 처리
            Debug.Log("충돌");
        }
    }

    IEnumerator Slide()
    {
        isSliding = true;

        // 콜라이더 크기 줄이기 (슬라이딩 효과)
        _collider.size = new Vector2(originalColliderSize.x /2 , originalColliderSize.y );
        _collider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y / 4));

        // 스프라이트 변경
        _spriteRenderer.sprite = slideSprite;

        yield return new WaitForSeconds(slideDuration); // 일정 시간 후 해제

        // 원래 크기로 복귀
        _collider.size = originalColliderSize;
        _collider.offset = originalColliderOffset;

         // 원래 스프라이트로 복구
        _spriteRenderer.sprite = normalSprite;

        // 원래 스케일로 복구
        transform.localScale = originalScale;

        isSliding = false;

        
    }

}
