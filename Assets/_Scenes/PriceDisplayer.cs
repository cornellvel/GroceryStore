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
<<<<<<< HEAD
        MyText.text = "$" + CartTrigger.carttrigger.Total;
=======
        //MyText.text = "$" + carttrigger.Total;
>>>>>>> c9e0e30c8672a1f6da7c4d3246365ee7b60bbe71

        //need to attach CartTrigger to shopping cart
        //This script should display the total 
    }
}
