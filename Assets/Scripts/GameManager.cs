using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update() { }

    //SpawnTarget is used to spawn objects randomly
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }
}
