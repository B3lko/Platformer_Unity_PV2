using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    bool shoot = false;
    private Animator miAnimator;
    private SpriteRenderer miSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable() {
        miAnimator = GetComponent<Animator>();
         miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !shoot){
            miAnimator.SetBool("Shooting",true);
            miAnimator.Play("Shoot");
            shoot = true;
            GameObject bullet = BulletPool.Instance.RequestBullet();
            if(!miSpriteRenderer.flipX){
                bullet.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                bullet.GetComponent<BulletController>().setDir(true);

            }
            else{
                bullet.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                bullet.GetComponent<BulletController>().setDir(false);
            }
        }
        else if(!Input.GetKey(KeyCode.Space) && shoot){
            miAnimator.SetBool("Shooting",false);
            shoot = false;
        }
    }
}
