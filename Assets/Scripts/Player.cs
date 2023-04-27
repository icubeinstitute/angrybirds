using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float force = 5f;

    Transform pivot;
    GameManager gameManager;
    Camera cam;

    Rigidbody2D rb;
    LineRenderer lineRenderer;

    Vector3 tempPos;
    Vector3 dir;
    Vector3 startPos;
    bool canBeMoved = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        cam = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
        pivot = GameObject.FindGameObjectWithTag("Pivot").transform;
        lineRenderer.SetPosition(0, pivot.position);
        lineRenderer.SetPosition(1, transform.position);
        startPos = transform.position;
        RotatePlayer();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            gameManager.ReloadScene();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ResetPlayer();
        }
    }

    private void OnMouseDrag()
    {
        if (canBeMoved)
        {
            tempPos = cam.ScreenToWorldPoint(Input.mousePosition);
            tempPos.z = 0;
            transform.position = tempPos;
            dir = pivot.position - transform.position;
            lineRenderer.SetPosition(1, transform.position);
            RotatePlayer();
        }
    }

    private void OnMouseUp()
    {
        if (canBeMoved)
        {
            rb.gravityScale = 1f;
            rb.AddForce(dir * force, ForceMode2D.Impulse);
            lineRenderer.SetPosition(1, pivot.position);
            canBeMoved = false;
        }
    }

    void ResetPlayer()
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        transform.position = startPos;
        lineRenderer.SetPosition(1, transform.position);
        RotatePlayer();
        canBeMoved = true;
    }

    void RotatePlayer()
    {
        Vector3 diff = transform.position - pivot.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f,0f,rotZ + 90);
    }
}
