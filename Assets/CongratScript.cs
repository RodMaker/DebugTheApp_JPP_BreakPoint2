using System.Collections;
using System.Collections.Generic; // added to fix
using UnityEngine;
using UnityEngine.UI; // added to fix

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay;
    
    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        TextToDisplay = new List<string>(); // added to fix

        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];
        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        Text.gameObject.transform.Rotate(0, RotatingSpeed, 0); // added to have a rotation

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            
            CurrentText++;

            Text.text = TextToDisplay[CurrentText]; // switched here
            
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;

                Text.text = TextToDisplay[CurrentText]; // (original broken code)
            }
        }

        Debug.Log("Current Text = " + CurrentText); // added to check if the counter was working
    }
}