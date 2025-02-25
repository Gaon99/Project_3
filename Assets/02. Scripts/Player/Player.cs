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
    public int maxJump = 2;
    public float slideDuration = 1f;
    public float maxHP = 100f;

    bool isSliding = false;
    bool isFlap = false;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;

    Vector3 originalScale;

    public Sprite normalSprite;
    public Sprite slideSprite;
    public Sprite jumpSprite;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        originalColliderSize = _collider.size;
        originalColliderOffset = _collider.offset;


        originalScale = transform.localScale;


        _spriteRenderer.sprite = normalSprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSliding && jumpCount < maxJump)
        {
            isFlap = true;
            jumpCount++;
            _spriteRenderer.sprite = jumpSprite;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && jumpCount == 0)
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
            maxHP -= 10; // 장애물에 부딪히면 체력 감소
            Debug.Log("충돌");
            Debug.Log("HP -10");
        }
    }

    IEnumerator Slide()
    {
        isSliding = true;


        
        _collider.size = new Vector2(originalColliderSize.x / 2, originalColliderSize.y);
        _collider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y / 4));

        
        _spriteRenderer.sprite = slideSprite;

        yield return new WaitForSeconds(slideDuration); 

        
        _collider.size = originalColliderSize;
        _collider.offset = originalColliderOffset;

        
        _spriteRenderer.sprite = normalSprite;

        
        transform.localScale = originalScale;

        isSliding = false;
    }

    public void IncreaseSpeed(float speed)
    {
        forwardSpeed += speed; // 아이템 먹으면 속도증가
    }
}
