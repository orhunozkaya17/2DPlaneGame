using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    bool gameover = false;

    Rigidbody2D rb;
    Camera cam;
    public AudioClip auC;
    public AudioSource auS;
    [SerializeField] Text scoreText;

    float cpt = 0;
    int scr = 0;
    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        
    }
    void setScore()
    {
        cpt += Time.deltaTime;
        if (cpt >=0.5f)
        {
            cpt = 0;
            scr++;
            scoreText.text = scr.ToString("000");
        }
    }
    private void Update()
    {

        if (!gameover)
        {
            setScore();
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * (rotationSpeed) * Time.deltaTime);
            }
        }
    }
    private void FixedUpdate()
    {
        if (!gameover)
        {
            rb.AddRelativeForce(new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0));
        }
    }
    private void LateUpdate()
    {
        if (!gameover)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameover)
        {
            gameover = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            auS.PlayOneShot(auC);
            Invoke("Resert", 2f);
        }
    }
    void Resert()
    {
        SceneManager.LoadScene(0);
    }
}
