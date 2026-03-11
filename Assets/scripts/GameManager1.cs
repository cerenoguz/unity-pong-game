using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    [SerializeField] TMP_Text score1text;
    [SerializeField] TMP_Text score2text;
    public static TMP_Text _score1text;
    public static TMP_Text _score2text;
    GameObject theBall;
    [SerializeField] GameObject Win1Panel;
    [SerializeField] GameObject Win2Panel;
    [SerializeField] TrailRenderer tail;
    public static TrailRenderer _tail;



    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    private void FixedUpdate()
    {
        if (PlayerScore1 == 10)
        {
            Win1Panel.SetActive(true);
            Time.timeScale = 0;

        }
        else if (PlayerScore2 == 10)
        {
            Win2Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void Awake()
    {
        _score1text = score1text;
        _score2text = score2text;
        _tail = tail;
    }
    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
    
            _score1text.text = PlayerScore1.ToString();
            _tail.Clear();
            _tail.enabled = false;

        }
        else
        {
            PlayerScore2++;
            _score2text.text = PlayerScore2.ToString();
            _tail.Clear();
            _tail.enabled = false;
        }
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        SceneManager.LoadScene("SampleScene");

    }

}