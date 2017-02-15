using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PriceDisplayer : MonoBehaviour
{

    public GameObject Whatever;



    public double Total = 60.0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {

            if (other.gameObject.GetComponent<FoodController>().InCart == true)
            {
                other.gameObject.GetComponent<FoodController>().InCart = false;
                Total = Total + other.gameObject.GetComponent<FoodController>().Price;

            }
            else
            {
                other.gameObject.GetComponent<FoodController>().InCart = true;
                Total = Total - other.gameObject.GetComponent<FoodController>().Price;
            }
        }
    }

    void Start()
    {
        GameObject Cart = GameObject.Find("GameObject");
        CartTrigger carttrigger = Cart.GetComponent<CartTrigger>();

    }

    void Update()
    {

        TextMesh MyText = Whatever.GetComponent<TextMesh>();
        //MyText.text = "$" + carttrigger.Total;

        //need to attach CartTrigger to shopping cart
        //This script should display the total 
    }
}
