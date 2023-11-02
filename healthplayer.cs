using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class healthplayer : MonoBehaviour
{
    public int health = 24;
    public int numofhearts = 12;
    public Image[] hearts;
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    public Shield ss;
    private bool flag = false;

    public AudioSource deadd;
    public AudioSource gethitt;
    bool slow = false;
    bool invc = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))

        //{
        //    health = health + 10;

        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    invc = !invc;

        //}
        //if (Input.GetKeyDown(KeyCode.T))
        //{
            
        //        Time.timeScale = 1f;
              
          

        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    Time.timeScale = 0.5f;

        //}

    }

    private void die()
    {


        SceneManager.LoadScene(0);

    }

    public void TakeDamage(int damageAmount)
    {
        if (invc)
            return;
        if (ss.time <= 0)
        {
            this.GetComponent<Animator>().SetTrigger("gothit");
            gethitt.Play();
            health -= damageAmount;
            if (health <= 0)
            {
                this.GetComponent<Animator>().SetTrigger("die");
                deadd.Play();
                flag = true;
                Invoke("die", 2.5f);

            }
            if (health > 0)
            {

                Debug.Log(health + "asdasdasdawdaw");

                int heartindex = health / 2;
                if (health % 2 == 1)
                {
                    for (int l = hearts.Length - 1; l > heartindex - 1; l--)
                    {
                        hearts[l].sprite = empty;
                    }

                    if ((hearts[heartindex - 1].sprite = half) !=null)

                    hearts[heartindex - 1].sprite = half;
                }
                else
                {
                    for (int l = hearts.Length - 1; l > heartindex - 1; l--)
                    {
                        hearts[l].sprite = empty;
                    }
                    hearts[heartindex - 1].sprite = empty;
                }
            }
        }
    }

}