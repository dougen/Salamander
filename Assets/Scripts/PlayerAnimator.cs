using UnityEngine;

public class PlayerAnimator : MonoBehaviour 
{
    public Sprite shipNormal;
    public Sprite shipLeft;
    public Sprite shipRight;
    public GameObject fire;

    private Animator animator;
    private PlayerControls pc;

	// Use this for initialization
	private void Start () 
    {
        animator = fire.GetComponent<Animator>();
        pc = GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	private void Update () 
    {
        // 用来控制飞机的精灵显示
        Vector2 speed = GetComponent<Rigidbody2D>().velocity;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        if (speed.x == 0 && sprite != shipNormal)
        {
            sprite = shipNormal;
        }
        else if (speed.x < 0 && sprite != shipLeft)
        {
            sprite = shipLeft;
        }
        else if (speed.x > 0 && sprite != shipRight)
        {
            sprite = shipRight;
        }

        GetComponent<SpriteRenderer>().sprite = sprite;

        // 用来控制火焰的大小
        animator.SetBool("isRushing", pc.isRushing);
	}
}
