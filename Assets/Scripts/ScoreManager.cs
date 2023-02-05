using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text ScoreText;
    [SerializeField] Text FinisScoreText;
    public ParticleSystem particle;


    // Gold send UI
    [SerializeField] GameObject goldPrefeb;
    [SerializeField] GameObject scoreArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);

            // particle Instantiate 

            Instantiate(particle, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z), Quaternion.identity);
            particle.Play();

            // to make big your character

            transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);

            // Gold UI send Instantiate 

            Instantiate(goldPrefeb, Camera.main.WorldToScreenPoint(transform.position), scoreArea.transform.rotation, scoreArea.transform);


        }

        ScoreUpdate();
    }

    // both score update first one in game score second finis score
    public void ScoreUpdate() 
    {
        
        ScoreText.text = score.ToString();
        FinisScoreText.text = score.ToString();
    }

    // to high the speed of the character
    public bool Scorevalue()
    {
        return true;
    }
}
