using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public GameObject fire;

    private Animator animator;
    private Rigidbody2D rigid2d;

	// Use this for initialization
	private void Start () 
    {
        animator = fire.GetComponent<Animator>();
        rigid2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () 
    {
	    
	}

    // 碰撞检测函数，当检测到碰撞体为柱子时，游戏结束
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bars")
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // 碰撞时播放爆炸特效
        animator.SetTrigger("Explosion");

        // 将飞船取消显示
        GetComponent<SpriteRenderer>().enabled = false;

        // 设置碰撞组件失效，防止继续碰撞
        GetComponent<BoxCollider2D>().enabled = false;

        // 设置停止移动
        GetComponent<PlayerControls>().enabled = false;
        rigid2d.velocity = new Vector2(0, 0);
        Debug.Log("Game Over");
    }
}
