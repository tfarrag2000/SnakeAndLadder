using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Roll : MonoBehaviour
{

    // Use this for initialization
    public Text newDieVal;
    public Image newDieIm;
    public SpriteRenderer p1;
    public SpriteRenderer p2;
    public Text status;
    public Text S_L;
    public Sprite[] ImgList;
    public Button playbutton;
    public AudioSource sAudio;
    public AudioSource LAudio;
    public AudioSource WAudio;
    public GameObject panel;

    public static Dictionary<int, Vector3> positions;

    private int p1_pos = 0;
    private int p2_pos = 0;
    private int currentplayer = 1;

    void Start()
    {
        positions = new Dictionary<int, Vector3>();
        float x,  y;
        x = -4.9f;
        y = -4.5f;
        for (int i = 1; i <= 100; i++)
        {
            positions.Add(i, new Vector3(x, y, 0));
            x += 1.1f;

            if (i % 10 == 0)
            {
                y += 1f;
                x = -4.9f;
            }

        }
        panel.gameObject.SetActive(false);

    }

    public void OnButtonClick()
    {
        int n = Random.Range(1, 7);
        newDieVal.text = n.ToString();
        newDieIm.sprite = ImgList[n];

        if (currentplayer == 1)
        {
            p1_pos += n;
            p1_pos = CheckSnake(p1_pos);
            p1_pos = CheckLadder(p1_pos);

            currentplayer = 2;
            status.text = "Player 2 is playing";

            if (p1_pos >= 100)
            {
                p1_pos = 100;
                showMsg("Player 1 is the winner", Color.green);
                currentplayer = 1;
                WAudio.Play();
            }
            p1.transform.position = positions[p1_pos];
        }
        else if (currentplayer == 2)
        {
            p2_pos += n;
            p2_pos = CheckSnake(p2_pos);
            p2_pos = CheckLadder(p2_pos);

            currentplayer = 1;
            status.text = "Player 1 is playing";

            if (p2_pos >= 100)
            {
                p2_pos = 100;
                showMsg("Player 2 is the winner", Color.green);
                currentplayer = 2;
                WAudio.Play();
            }
            p2.transform.position = positions[p2_pos];

        }
    }


    private int CheckSnake(int oldPos)
    { int newPos = oldPos;
        string s = "";
        if (oldPos == 16)
        {
            newPos = 6;
            s = "you gave your password to a friend";
        }
        else if (oldPos == 49)
        {
            newPos = 11;
            s = "your password is easy to guess";
        }
        else if(oldPos == 46)
        {
            newPos = 25;
            s = "you used you name or your pets name as your password";
        }
        else if(oldPos == 62)
        {
            newPos = 19;
            s = "you wrote your password down";
        }
        else if (oldPos == 64)
        {
            newPos = 60;
            s = "you used the same password everywhere";
        }
        else if (oldPos == 74)
        {
            newPos = 53;
            s = "your password is less than 5 characters";
        }
        else if (oldPos == 89)
        {
            newPos = 68;
            s = "you gave your password to a friend";
        }
        else if (oldPos == 92)
        {
            newPos = 88;
            s = "your password is easy to guess";
        }
        else if (oldPos == 95)
        {
            newPos = 75;
            s = "you used you name or your pets name as your password";
        }
        else if (oldPos == 99)
        {
            newPos = 80;
            s = "you wrote your password down";
        }


        if (oldPos != newPos)
        {
            string ss = string.Format("Snake down from {0} to {1}", oldPos, newPos) + "\n" + s;
            showMsg(ss, Color.red);
            sAudio.Play();
        }

        return newPos;
    }

    private int CheckLadder(int oldPos)
    {
        int newPos = oldPos;
        string s = "";
        if (oldPos == 2)
        {
            newPos = 38;
            s = "you gave your password to your parent or guardian";       
        }
        else if (oldPos == 15)
        {
            newPos = 26;
            s = "your password is at least 8 characters long";
        }
        else if (oldPos == 7)
        {
            newPos = 14;
            s = "you change your password once a month";

        }
        else if (oldPos == 8)
        {
            newPos = 31;
            s = "your password not a word in the dictionary";
        }
        else if (oldPos == 36)
        {
            newPos = 44;
            s = "you used characters like # ,$ ,* in your password";
        }
        else if (oldPos == 21)
        {
            newPos = 42;
            s = "you gave your password to your parent or guardian";

        }
        else if (oldPos == 28)
        {
            newPos = 84;
            s = "your password is at least 8 characters long";
        }
        else if (oldPos == 51)
        {
            newPos = 67;
            s = "you change your password once a month";
        }
        else if (oldPos == 78)
        {
            newPos = 98;
            s = "your password not a word in the dictionary";

        }
        else if (oldPos == 71)
        {
            newPos = 91;
            s = "you used characters like # ,$ ,* in your password";
        }

        if (oldPos != newPos)
        {
            string ss = string.Format("Ladder up from {0} to {1}", oldPos, newPos) + "\n" + s;
            showMsg(ss, Color.yellow);
            LAudio.Play();
        }
        return newPos;
    }
    
    public void onOKclick()
    {
        panel.gameObject.SetActive(false);
        playbutton.interactable = true;
    }


    public void showMsg(string s ,Color c)
    {
        S_L.text = s;
        S_L.color = c;
        panel.gameObject.SetActive(true);
        playbutton.interactable = false;
    }
}
