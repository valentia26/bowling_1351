using UnityEngine;
using UnityEngine.InputSystem;

public class Bowling : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private int forcePower;

    [SerializeField]
    private GameObject shootButton; // ลาก Button (UI) มาใส่ใน Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            MoveRight();
        }

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            MoveLeft();
        }
    }

    public void ShootBall()
    {
        if (rb == null) return;

        rb.AddForce(Vector3.forward * forcePower, ForceMode.Impulse);

       
        if (shootButton != null)
            shootButton.SetActive(false);
    }

    private void MoveRight()
    {
        transform.position += new Vector3(0.5f, 0f, 0f);
            }

    private void MoveLeft()
    {
        transform.position -= new Vector3(0.5f, 0f, 0f) * Time.deltaTime;
    }
}