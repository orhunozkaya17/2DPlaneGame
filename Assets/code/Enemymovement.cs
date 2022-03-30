using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform Player;

    
    bool gameover = false;

    Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("a");

    }
    private void Update()
    {

        Vector2 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion r = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, r, rotationSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (!gameover)
        {
            rb.AddRelativeForce(new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0));
        }
    }
  

}
