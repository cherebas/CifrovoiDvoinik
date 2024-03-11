using UnityEngine;

public class CarControls : MonoBehaviour
{
    public GameObject loseUI;
    public void moveLeft()
    {
        if(transform.position.x > -4f)
            transform.position = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
    }

    public void moveRight()
    {
        if(transform.position.x < 4f)
            transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            moveRight();
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            moveLeft();
    }

    private void OnCollisionEnter(Collision other)
    {
        loseUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
