using UnityEngine;

public class StarScript : MonoBehaviour 
{
    public float rotSpeed;              //围绕Y轴旋转速度
	// Use this for initialization
	private void Start () 
    {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime, Space.Self);
	}
}
