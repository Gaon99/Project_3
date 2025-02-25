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
    public int maxJump = 2; // �ִ� ���� 2ȸ ����
    public float slideDuration = 1f; // �����̵� ���ӽð�
    public int health;

    bool isSliding = false;
    bool isFlap = false;
    private Vector2 originalColliderSize; // ������ �ݶ��̴� ũ��
    private Vector2 originalColliderOffset; // ������ �ݶ��̴� ��ġ

    Vector3 originalScale;  // ������ �������� ������ ����

    public Sprite normalSprite;  // ���� ��������Ʈ
    public Sprite slideSprite;   // �����̵��� ���� ��������Ʈ
    public Sprite jumpSprite;   // ������ ���� ��������Ʈ
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();


        // ������ �ݶ��̴� ũ�� ����
        originalColliderSize = _collider.size;
        originalColliderOffset = _collider.offset;

        // ������ ������ ����
        originalScale = transform.localScale;

        // ������ ��������Ʈ ����
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && jumpCount == 0) // ���߿����� �����̵� �Ұ�
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
            jumpCount = 0; // �ٴڿ� ������ ���� Ƚ�� �ʱ�ȭ
            _spriteRenderer.sprite = normalSprite; // ���� ��������Ʈ�� ����

        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.CollisionObstacle(); // ��ֹ� �浹 ó��
            Debug.Log("�浹");
        }
    }

    IEnumerator Slide()
    {
        isSliding = true;

        // �ݶ��̴� ũ�� ���̱� (�����̵� ȿ��)
        _collider.size = new Vector2(originalColliderSize.x /2 , originalColliderSize.y );
        _collider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y / 4));

        // ��������Ʈ ����
        _spriteRenderer.sprite = slideSprite;

        yield return new WaitForSeconds(slideDuration); // ���� �ð� �� ����

        // ���� ũ��� ����
        _collider.size = originalColliderSize;
        _collider.offset = originalColliderOffset;

         // ���� ��������Ʈ�� ����
        _spriteRenderer.sprite = normalSprite;

        // ���� �����Ϸ� ����
        transform.localScale = originalScale;

        isSliding = false;

        
    }

}
