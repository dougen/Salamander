using UnityEngine;

public class PlayerManager : MonoBehaviour 
{

	// Use this for initialization
	private void Start () 
    {
	
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
            Debug.Log("Game Over");
        }
    }
}
