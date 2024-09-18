using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color playerColor = Color.white;
    public Color enemyColor = Color.white; 
    private static SaveController _instance;

    public string namePlayer = "Player";
    public string nameEnemy = "Enemy";

    public string saveWinnerKey = "SavedWinner";

    public static SaveController Instance
    {
        get {
            if (_instance == null) {
                // Procure  instância na cena
                _instance = FindObjectOfType<SaveController>();

                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake() {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;

        }
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset() {
        namePlayer = "";
        nameEnemy = "";
        playerColor = Color.white;
        enemyColor = Color.red;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
