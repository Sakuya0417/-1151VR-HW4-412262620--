using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float boostForce = 6f;
    public AudioClip flyingSound;
    public AudioClip crashSound;
    public AudioClip passSound;
    
    private Rigidbody rb;
    private AudioSource audioSource;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
        // 遊戲開始，播放引擎聲
        if (flyingSound != null)
        {
            audioSource.clip = flyingSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (isDead) return;

        // 1. 強制物理推進 (解決穿隧效應)
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, forwardSpeed);

        // 2. 點擊起飛 (支援左鍵與空白鍵)
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, boostForce, rb.linearVelocity.z);
        }
    }

    // --- 觸發區判定 (隱形的 ScoreZone) ---
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("【穿過觸發區】摸到了：" + other.gameObject.name + "，標籤是：" + other.gameObject.tag);
        
        if (other.gameObject.CompareTag("ScoreZone") && !isDead)
        {
            Debug.Log("【得分】成功觸發 Pass，準備播放音效！");
            if (passSound != null) audioSource.PlayOneShot(passSound);
        }
    }

    // --- 實體撞擊判定 (實體的 Obstacle 柱子) ---
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("【實體撞擊】撞到了：" + collision.gameObject.name + "，標籤是：" + collision.gameObject.tag);
        
        if (collision.gameObject.CompareTag("Obstacle") && !isDead)
        {
            isDead = true;
            audioSource.Stop(); // 停掉引擎聲
            if (crashSound != null) audioSource.PlayOneShot(crashSound);
        }
    }
}