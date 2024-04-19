using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] TutoPage;
    [SerializeField] GameObject[] Uies;
    [SerializeField]int count=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (count == 10) SceneManager.LoadScene("PlayTutorial");
            TutoPage[count - 1].SetActive(false);
            if (count-1 == 3) Uies[0].SetActive(false);
            if (count-1 == 5) Uies[1].SetActive(false);
            if (count-1 == 7) Uies[2].SetActive(false);
            if (count-1 == 8) Uies[3].SetActive(false);

            TutoPage[count].SetActive(true);
            if (count == 3) Uies[0].SetActive(true);
            if (count == 5) Uies[1].SetActive(true);
            if (count == 7) Uies[2].SetActive(true);
            if (count == 8) Uies[3].SetActive(true);
            count++;
        }
    }
}
