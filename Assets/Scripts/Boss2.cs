using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : Enemy
{

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
    void BossDefeated()
    {
        Invoke("LoadScene", 8f);
    }
    public new void TookDamage(int damage)
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

    public new void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }
    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}