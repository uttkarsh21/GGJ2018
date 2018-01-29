using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

    [SerializeField]
    private Sprite left,right,up,down;
    
    [SerializeField]
    private Text score_text;

    private int scoring = 0;

    bool gameover = false;

    float timer = 2f;
    float delay = 2f;

    int random_sprite;

    private void Start()
    {
        gameover = false;
        random_sprite = Random.Range(1, 4);
        switch (random_sprite)
        {
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = down;
                break;
            default:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
                break;
        }
    }

private void Update()
    {
        timer -= Time.deltaTime;
        random_sprite = Random.Range(1, 4);

        if (timer<=0)
        {
            switch (random_sprite)
            {
                case 1: this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
                        break;
                case 2: this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
                        break;
                case 3: this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
                        break;
                case 4: this.gameObject.GetComponent<SpriteRenderer>().sprite = down;
                        break;
                default: this.gameObject.GetComponent<SpriteRenderer>().sprite = up;
                         break;
            }

            timer = delay;
            return;
        }
    }

    void score()
    {
        Debug.Log(scoring);
        score_text.text = scoring.ToString();
        PlayerPrefs.SetInt("final_score", scoring);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("scoring" + random_sprite + collision.gameObject.tag);

     
        if (collision.gameObject.CompareTag("up") && random_sprite == 3)
                scoring += 1;
            else
        if (collision.gameObject.CompareTag("down") && random_sprite == 4)
                    scoring += 1;
                else
            if (collision.gameObject.CompareTag("right") && random_sprite == 2)
                        scoring += 1;
                    else
                if (collision.gameObject.CompareTag("left") && random_sprite == 1)
                            scoring += 1;
                        else
                            gameover = true;

        if(gameover)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        score();
    }
}
