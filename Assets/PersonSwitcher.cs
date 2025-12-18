using UnityEngine;

public class PersonSwitcher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float person = 1;
    public GameObject kreston;
    public GameObject david;
    public GameObject john;
    public GameObject cerese;
    public GameObject cerese2;
    public GameObject chloe;

    void Update()
    {
        if (person == 1)
        {
            kreston.SetActive(true);
            david.SetActive(false);
            john.SetActive(false);
            cerese.SetActive(false);
            cerese2.SetActive(false);
            chloe.SetActive(false);

            Debug.Log("Kreston G.");
        }
        if (person == 2)
        {
            kreston.SetActive(false);
            david.SetActive(true);
            john.SetActive(false);
            cerese2.SetActive(false);
            cerese.SetActive(false);
            chloe.SetActive(false);

            Debug.Log("David");
        }
        if (person == 3)
        {
            kreston.SetActive(false);
            david.SetActive(false);
            john.SetActive(false);
            cerese2.SetActive(false);
            cerese.SetActive(false);
            chloe.SetActive(true);

            Debug.Log("Chloe");
        }
        if (person == 4)
        {
            kreston.SetActive(false);
            david.SetActive(false);
            john.SetActive(true);
            cerese2.SetActive(false);
            cerese.SetActive(false);
            chloe.SetActive(false);

            Debug.Log("John L.");
        }
        if (person == 5)
        {
            kreston.SetActive(false);
            david.SetActive(false);
            john.SetActive(false);
            cerese2.SetActive(false);
            cerese.SetActive(true);
            chloe.SetActive(false);

            Debug.Log("Cerese1");
        }
        if (person == 6)
        {
            kreston.SetActive(false);
            david.SetActive(false);
            john.SetActive(false);
            cerese2.SetActive(true);
            cerese.SetActive(false);
            chloe.SetActive(false);

            Debug.Log("Cerese2");
        }
        if (person == 0)
        {
            person = 6;
        }
        if (person == 6)
        {
            person = 0;
        }
    }
    public void onNext()
    {
        person += 1;
    }


    public void onBack()
    {
        person -= 1;
    }
}
