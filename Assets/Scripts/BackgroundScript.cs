using UnityEngine;

public class BackgroundScript : MonoBehaviour 
{
    public float scrollSpeed = 0.5f;     // 普通速度下背景的移动速度
    public float rushSpeed = 1.5f;      // 在冲刺技能下背景的移动速度
    public PlayerControls pc;

	// Use this for initialization
	private void Start () 
    {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
	    // 让背景缓慢移动
        float offset = 0;
        if (pc.isRushing)
        {
            offset = Time.deltaTime * rushSpeed;
        }
        else
        {
            offset = Time.deltaTime * scrollSpeed;
        }
        
        transform.Translate(new Vector2(0, offset));

        if (transform.position.y <= -14)
        {
            transform.position = new Vector2(0, 14f);
        }
	}
}
