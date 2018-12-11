using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float maxSpeed = 4;
    public float jumpForce = 400;
    public float minHeight, maxHeight;
    public float maxHp = 200; 
    public float HP = 200;
    public float maxUltimate = 100.0f;
    public float ultimate= 0.0f; //궁극기 게이지

    private float currentHP;
    private float currentSpeed;
    private Rigidbody rb;
    private Animator anim;
    private Transform groundCheck;
    private bool onGround;
    private bool isDead = false;
    private bool facingRight = true;
    private bool jump = false;

    private Slider hpGage;
    private Slider ultimateGage;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");

        currentSpeed = maxSpeed;
        currentHP = maxHp;
        
        hpGage = GameObject.Find("Canvas").transform.Find("HpGage").GetComponent<Slider>();
        
        ultimateGage = GameObject.Find("Canvas").transform.Find("UltimateGage").GetComponent<Slider>();



    }
	
	// Update is called once per frame
	void Update () {

        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("OnGround", onGround);
        anim.SetBool("Dead", isDead);

        hpGage.value = HP / maxHp;
        ultimateGage.value = ultimate / maxUltimate;

        if (Input.GetKey(KeyCode.C))
        {
            HP -= 10;

            ultimate += 8;
        }

        if(Input.GetButtonDown("Jump")&&onGround)
        {
            jump = true;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
		
	}
    private void FixedUpdate()
    {
        if (!isDead)
        {
            float h = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (!onGround)
                z = 0;
            rb.velocity = new Vector3(h * currentSpeed, rb.velocity.y, z * currentSpeed);

            if (onGround)
                anim.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));

            if (h > 0 && !facingRight)
            {
                Flip();
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }
            if (jump)
            {
                jump = false;
                rb.AddForce(Vector3.up * jumpForce);
            }
            float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
            float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minWidth + 1, maxWidth - 1), rb.position.y, Mathf.Clamp(rb.position.z, minHeight, maxHeight));
        }
    }
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void ZeroSpeed()
    {
        currentSpeed = 0;
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }
    
    public void TookDamage(int damage)
    {
        if (!isDead)
        {
            currentHP -= damage;
            anim.SetTrigger("HitDamage");
            
        }
    }
}
