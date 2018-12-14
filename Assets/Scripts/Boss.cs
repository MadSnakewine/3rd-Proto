using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxSpeed;
    public float minHeight, maxHeight;
    public float damageTime = 0.5f;
    public int maxHealth;
    public float attackRate = 1f;

    private int currentHealth;
    private float currentSpeed;
    private Rigidbody rb;
    private Animator anim;
    private Transform groundCheck;
    private bool onGround;
    private Transform target;
    private float zForce;
    private float walkTimer;
    private bool damaged = false;
    private float damageTimer;
    private float nextAttack;
    protected bool facingRight = false;
    protected bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        target = FindObjectOfType<Player>().transform;
        currentHealth = maxHealth;
    }
 
    void Update()
    {

        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Grounded", onGround);
        anim.SetBool("Dead", isDead);

        facingRight = (target.position.x < transform.position.x) ? false : true;
        if (facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (damaged && !isDead)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageTime)
            {
                damaged = false;
                damageTimer = 0;
            }
        }
        if (isDead)
        {
            Destroy(gameObject, 1f);
        }
        walkTimer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 targetDitance = target.position - transform.position;
            float hForcee = targetDitance.x / Mathf.Abs(targetDitance.x);

            if (walkTimer >= Random.Range(1f, 2f))
            {
                zForce = Random.Range(-1, 2);
                walkTimer = 0;
            }

            if (Mathf.Abs(targetDitance.x) < 1.5f)
            {
                hForcee = 0;
            }

            if (!damaged)

                rb.velocity = new Vector3(hForcee * currentSpeed, 0, zForce * currentSpeed);

            anim.SetFloat("Speed", Mathf.Abs(currentSpeed));

            if (Mathf.Abs(targetDitance.x) < 1.5f && Mathf.Abs(targetDitance.z) < 1.5f && Time.time > nextAttack)
            {
                anim.SetTrigger("Attack");
                currentSpeed = 0;
                nextAttack = Time.time + attackRate;
            }
        }
        rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }
    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            damaged = true;
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            if (currentHealth <= 0)
            {
                isDead = true;
                rb.AddRelativeForce(new Vector3(3, 5, 0), ForceMode.Impulse);
            }
        }
    }

    public void DisabledBoss()
    {
        gameObject.SetActive(false);
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }
    void BossDefeated()
    {
        Invoke("LoadScene", 4f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
