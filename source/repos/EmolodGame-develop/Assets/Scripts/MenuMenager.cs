using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{

    [SerializeField] private List<GameObject> MenuList;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ContGame()
    {
        
    }
    public void Setting()
    {
        MenuList[2].SetActive(true);
    }


    public void Exit()
    {
        MenuList[1].SetActive(true);
    }
    public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        MenuList[1].SetActive(false);
    }
}
