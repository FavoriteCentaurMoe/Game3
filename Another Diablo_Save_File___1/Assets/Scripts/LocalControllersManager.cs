﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalControllersManager : MonoBehaviour {
    public string player1;
    public string player1Character;
    public string player2;
    public string player2Character;
    public string player3;
    public string player3Character;
    public string player4;
    public string player4Character;
    Scene current_scene;
    public List<int> plrsSet = new List<int>();
    public bool plr1Set, plr2Set, plr3Set, plr4Set;

    private List<string> PlayerClass = new List<string> { "Warrior", "SharpShooter", "Mage", "Medic" }; //Limited characters for now
    private int p1ClassCounter;
    private int p2ClassCounter;
    private int p3ClassCounter;
    private int p4ClassCounter;
    public float p1ScrollTime;
    public float p2ScrollTime;
    public float p3ScrollTime;
    public float p4ScrollTime;

    public LocalControllersManager LCM;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        if (LCM == null)  //This happens to the script always exists, like it is static 
        {
            LCM = GameObject.FindGameObjectWithTag("GameController").GetComponent<LocalControllersManager>();
        }
        current_scene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (current_scene.name == "ControllerMapping")
        {
            SetUpControllers();
            ChooseCharacter();
        }
		
	}

    public void SetUpControllers()
    {
        if (!plr1Set)
        {
            if (Input.GetButton("Ctr 1 A Button") && !plrsSet.Contains(1))
            {
                player1 = "Ctr 1 ";
                plr1Set = true;
                plrsSet.Add(1);
                player1Character = PlayerClass[p1ClassCounter];
            }
            else if(Input.GetButton("Ctr 2 A Button") && !plrsSet.Contains(2))
            {
                player1 = "Ctr 2 ";
                plr1Set = true;
                plrsSet.Add(2);
                player1Character = PlayerClass[p1ClassCounter];
            }
            if (Input.GetButton("Ctr 3 A Button") && !plrsSet.Contains(3))
            {
                player1 = "Ctr 3 ";
                plr1Set = true;
                plrsSet.Add(3);
                player1Character = PlayerClass[p1ClassCounter];
            }
            else if (Input.GetButton("Ctr 4 A Button") && !plrsSet.Contains(4))
            {
                player1 = "Ctr 4 ";
                plr1Set = true;
                plrsSet.Add(4);
                player1Character = PlayerClass[p1ClassCounter];
            }
        }

        if (!plr2Set)
        {
            if (Input.GetButton("Ctr 1 A Button") && !plrsSet.Contains(1))
            {
                player2 = "Ctr 1 ";
                plr2Set = true;
                plrsSet.Add(1);
                player2Character = PlayerClass[p2ClassCounter];
            }
            else if (Input.GetButton("Ctr 2 A Button") && !plrsSet.Contains(2))
            {
                player2 = "Ctr 2 ";
                plr2Set = true;
                plrsSet.Add(2);
                player2Character = PlayerClass[p2ClassCounter];
            }
            else if (Input.GetButton("Ctr 3 A Button") && !plrsSet.Contains(3))
            {
                player2 = "Ctr 3 ";
                plr2Set = true;
                plrsSet.Add(3);
                player2Character = PlayerClass[p2ClassCounter];
            }
            else if (Input.GetButton("Ctr 4 A Button") && !plrsSet.Contains(4))
            {
                player2 = "Ctr 4 ";
                plr2Set = true;
                plrsSet.Add(4);
                player2Character = PlayerClass[p2ClassCounter];
            }
        }
        if (!plr3Set)
        {
            if (Input.GetButton("Ctr 1 A Button") && !plrsSet.Contains(1))
            {
                player3 = "Ctr 1 ";
                plr3Set = true;
                plrsSet.Add(1);
                player3Character = PlayerClass[p3ClassCounter];
            }
            else if (Input.GetButton("Ctr 2 A Button") && !plrsSet.Contains(2))
            {
                player3 = "Ctr 2 ";
                plr3Set = true;
                plrsSet.Add(2);
                player3Character = PlayerClass[p3ClassCounter];
            }
            if (Input.GetButton("Ctr 3 A Button") && !plrsSet.Contains(3))
            {
                player3 = "Ctr 3 ";
                plr3Set = true;
                plrsSet.Add(3);
                player3Character = PlayerClass[p3ClassCounter];
            }
            else if (Input.GetButton("Ctr 4 A Button") && !plrsSet.Contains(4))
            {
                player3 = "Ctr 4 ";
                plr3Set = true;
                plrsSet.Add(4);
                player3Character = PlayerClass[p3ClassCounter];
            }
        }

        if (!plr4Set)
        {
            if (Input.GetButton("Ctr 1 A Button") && !plrsSet.Contains(1))
            {
                player4 = "Ctr 1 ";
                plr4Set = true;
                plrsSet.Add(1);
                player4Character = PlayerClass[p4ClassCounter];
            }
            else if (Input.GetButton("Ctr 2 A Button") && !plrsSet.Contains(2))
            {
                player4 = "Ctr 2 ";
                plr4Set = true;
                plrsSet.Add(2);
                player4Character = PlayerClass[p4ClassCounter];
            }
            else if (Input.GetButton("Ctr 3 A Button") && !plrsSet.Contains(3))
            {
                player4 = "Ctr 3 ";
                plr4Set = true;
                plrsSet.Add(3);
                player4Character = PlayerClass[p4ClassCounter];
            }
            else if (Input.GetButton("Ctr 4 A Button") && !plrsSet.Contains(4))
            {
                player4 = "Ctr 4 ";
                plr4Set = true;
                plrsSet.Add(4);
                player4Character = PlayerClass[p4ClassCounter];
            }
        }

    }

    public int ChangeCharacter(int Counter, int direction)
    {
        int newVal = Counter + direction;
        int limit = PlayerClass.Count - 1;
        if (newVal < 0)
        {
            newVal = limit;
        }
        else if (newVal > limit)
        {
            newVal = 0;
        }
        return newVal;
    }

    public void ChooseCharacter()
    {
        if (plr1Set)
        {
            float scrollValue = Input.GetAxis(player1 + "Left Joystick Horizontal");
            if (scrollValue != 0.0f && p1ScrollTime <= Time.time)
            {
                p1ScrollTime = Time.time + 0.45f;
                if (scrollValue > 0.01f)
                {
                    p1ClassCounter = ChangeCharacter(p1ClassCounter, 1);
                }
                else if (scrollValue < -0.01f)
                {
                    p1ClassCounter = ChangeCharacter(p1ClassCounter, -1);
                }
                player1Character = PlayerClass[p1ClassCounter];
            }
            //if (Input.GetButton(player1 + "Y Button"))
            //{
            //    player1Character = "Warrior";
            //}
            //else if (Input.GetButton(player1 + "X Button"))
            //{
            //    player1Character = "Medic";
            //}
            //else if (Input.GetButton(player1 + "B Button"))
            //{
            //    player1Character = "SharpShooter";
            //}
            //else if (Input.GetButton(player1 + "A Button"))
            //{
            //    player1Character = "Mage";
            //}
        }

        if (plr2Set)
        {
            float scrollValue = Input.GetAxis(player2 + "Left Joystick Horizontal");
            if (scrollValue != 0.0f && p2ScrollTime <= Time.time)
            {
                p2ScrollTime = Time.time + 0.45f;
                if (scrollValue > 0.01f)
                {
                    p2ClassCounter = ChangeCharacter(p2ClassCounter, 1);
                }
                else if (scrollValue < -0.01f)
                {
                    p2ClassCounter = ChangeCharacter(p2ClassCounter, -1);
                }
                player2Character = PlayerClass[p2ClassCounter];
            }
            //if (Input.GetButton(player2 + "Y Button"))
            //{
            //    player2Character = "Warrior";
            //}
            //else if (Input.GetButton(player2+ "X Button"))
            //{
            //    player2Character = "Medic";
            //}
            //else if (Input.GetButton(player2 + "B Button"))
            //{
            //    player2Character = "SharpShooter";
            //}
            //else if (Input.GetButton(player2 + "A Button"))
            //{
            //    player2Character = "Mage";
            //}
        }

        if (plr3Set)
        {
            float scrollValue = Input.GetAxis(player3 + "Left Joystick Horizontal");
            if (scrollValue != 0.0f && p3ScrollTime <= Time.time)
            {
                p3ScrollTime = Time.time + 0.45f;
                if (scrollValue > 0.01f)
                {
                    p3ClassCounter = ChangeCharacter(p3ClassCounter, 1);
                }
                else if (scrollValue < -0.01f)
                {
                    p3ClassCounter = ChangeCharacter(p3ClassCounter, -1);
                }
                player3Character = PlayerClass[p3ClassCounter];
            }

            //if (Input.GetButton(player3 + "Y Button"))
            //{
            //    player3Character = "Warrior";
            //}
            //else if (Input.GetButton(player3 + "X Button"))
            //{
            //    player3Character = "Medic";
            //}
            //else if (Input.GetButton(player3 + "B Button"))
            //{
            //    player3Character = "SharpShooter";
            //}
            //else if (Input.GetButton(player3 + "A Button"))
            //{
            //    player3Character = "Mage";
            //}
        }

        if (plr4Set)
        {
            float scrollValue = Input.GetAxis(player4 + "Left Joystick Horizontal");
            if (scrollValue != 0.0f && p4ScrollTime <= Time.time)
            {
                p4ScrollTime = Time.time + 0.45f;
                if (scrollValue > 0.01f)
                {
                    p4ClassCounter = ChangeCharacter(p4ClassCounter, 1);
                }
                else if (scrollValue < -0.01f)
                {
                    p4ClassCounter = ChangeCharacter(p4ClassCounter, -1);
                }
                player4Character = PlayerClass[p4ClassCounter];
            }
            //if (Input.GetButton(player4 + "Y Button"))
            //{
            //    player4Character = "Warrior";
            //}
            //else if (Input.GetButton(player4 + "X Button"))
            //{
            //    player4Character = "Medic";
            //}
            //else if (Input.GetButton(player4 + "B Button"))
            //{
            //    player4Character = "SharpShooter";
            //}
            //else if (Input.GetButton(player4 + "A Button"))
            //{
            //    player4Character = "Mage";
            //}
        }
    }


}
