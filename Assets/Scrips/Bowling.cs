using UnityEngine;
using UnityEngine.InputSystem;

public class Bowling : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public static Bowling instance;

    [SerializeField]
    private int forcePower;

    [SerializeField]
    private GameObject shootButton;

    private bool hasShot = false; // เช็คว่ายิงไปแล้วหรือยัง

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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

        ShowHideShootBallButton(false);
        hasShot = true;
    }

    public void ShowHideShootBallButton(bool flag)
    {
        if (shootButton != null)
            shootButton.SetActive(flag);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasShot) return;

        if (collision.gameObject.CompareTag("Pin"))
        {
            if (BowlingScoreManager.instance != null)
                BowlingScoreManager.instance.CheckStrike();
        }
    }

    private void MoveRight()
    {
        transform.position += new Vector3(0.5f, 0f, 0f) * Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.position -= new Vector3(0.5f, 0f, 0f) * Time.deltaTime;
    }
}