using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy {

    void Update()
    {
        if (isDead)
        {
            Destroy(gameObject, 1f);
            
        }
    }
    
    void BossDefeated()
    {
        Invoke("LoadScene", 8f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
