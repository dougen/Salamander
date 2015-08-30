using UnityEngine;

public class PlayerAnimator : MonoBehaviour 
{
    public Sprite shipNormal;
    public Sprite shipLeft;
    public Sprite shipRight;

	// Use this for initialization
	private void Start () 
    {
        
	}
	
	// Update is called once per frame
	private void Update () 
    {

#if UNITY_STANDALONE

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

#endif


	}
}
