using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private HealthBar hpBar;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float detectionDist;
    [SerializeField] private Transform target;

    private Rigidbody2D rb;
    private Animator anim;

    public float currHp;
    public string ID;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currHp = maxHp;
        hpBar.UpdateHpBar(maxHp, currHp);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        ChasePlayer();
    }

    public void LoadState(float hp)
    {
        currHp = hp;
        hpBar.UpdateHpBar(maxHp, currHp);
    }

    public void TakeDamage(int damage)
    {
        currHp -= damage;
        hpBar.UpdateHpBar(maxHp, currHp);

        if (currHp <= 0)
        {
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
    }

    void ChasePlayer()
    {
        if (target == null)
        {
            Debug.Log("There is no target to chase");
            return;
        }  

        if (Vector2.Distance(transform.position, target.position) > detectionDist) return;

        Vector2 dir = (target.position - transform.position).normalized;
        rb.velocity = dir * speed;
        anim.SetFloat("Speed", rb.velocity.magnitude);

        Vector3 scale = transform.localScale;
        scale.x = dir.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }
}