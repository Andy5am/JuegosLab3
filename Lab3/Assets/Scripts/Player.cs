using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    private float contador;
    public GameObject coin;
    public GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb && Input.GetButtonDown("Jump"))
            if (Mathf.Abs(rb.velocity.y) < 0.005f)
                rb.AddForce(0, 3, 0,ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            contador++;
            Destroy(other.gameObject);
            texto.GetComponent<Text>().text = contador.ToString();
            if (contador == 5)
            {
                texto.transform.Find("llama").gameObject.SetActive(true);
                texto.GetComponent<Text>().color = Color.yellow;
            }
        }
        if (other.gameObject.tag == "Hole")
            if (contador != 5)
                Destroy(gameObject);
    }
}
