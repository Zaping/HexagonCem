using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Blocks : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    protected string color = "";
    public int columnNumber;

    int clickCount=1;
   
    public Transform selected_1;  
    public Transform selected_2;
    
    protected Vector3 spinPoint;   
    public bool spin=false;
    protected bool continueSpin=true;
    protected int spinCount;
    protected float TimeToRotate = 1f;
    protected Vector3 oldPosition0, oldPosition1, oldPosition2;
    protected Vector3 resetPosition = new Vector3(0, 0, 0);
    protected bool drag = false;

    protected SpawnBlocks spawn;
    protected Transform GameManager;
    protected int oldColumnNumber0;
    protected int oldColumnNumber1;
    protected int oldColumnNumber2;

    protected bool stopCollisionStay=false;
    protected bool FirstTarget = false;
    protected bool SecondTarget = false;
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.layer = default;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    
    protected void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(color)&&stopCollisionStay==false)
        {            
            if (collision.transform.position.y > transform.position.y)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, 60) * transform.up, .3f);
                if (hit != false)
                {
                    if (hit.transform.CompareTag(color))
                    {                       
                        stopCollisionStay = true;
                        continueSpin = false;
                        spinCount = 0;

                        if (hit.transform.gameObject.activeSelf)
                            spawn.SpawnBlock(hit.transform.gameObject.GetComponent<Blocks>().columnNumber);
                        if (collision.gameObject.activeSelf)
                            spawn.SpawnBlock(collision.gameObject.GetComponent<Blocks>().columnNumber);
                        if (gameObject.activeSelf)
                            spawn.SpawnBlock(columnNumber);
                        GameManagerScript.IsInputAvailable = true;
                        collision.gameObject.SetActive(false);
                        hit.transform.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                    }
                }
                        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, -60) * transform.up, .3f);
                        if (hit2 != false)
                        {
                            if (hit2.transform.CompareTag(color))
                            {                              
                                stopCollisionStay = true;
                                continueSpin = false;
                                spinCount = 0;
                                if(hit2.transform.gameObject.activeSelf)
                                    spawn.SpawnBlock(hit2.transform.gameObject.GetComponent<Blocks>().columnNumber);
                                if (collision.gameObject.activeSelf)
                                    spawn.SpawnBlock(collision.gameObject.GetComponent<Blocks>().columnNumber);
                                if (gameObject.activeSelf)
                                    spawn.SpawnBlock(columnNumber);
                        GameManagerScript.IsInputAvailable = true;
                        collision.gameObject.SetActive(false);
                                hit2.transform.gameObject.SetActive(false);
                                gameObject.SetActive(false);
                        
                            }
                        }                   
                
                                                           
            }
        }      
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {       
               
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {        
        if (spin == false && GameManagerScript.IsInputAvailable)
        {         
            FirstTarget = false;
            SecondTarget = false;
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            while (FirstTarget == false || SecondTarget == false)
            {               
                FirstTarget = false;
                SecondTarget = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, 60 * clickCount) * transform.up, 0.3f);
                if (hit != false)
                {                  
                    selected_1 = hit.transform;
                    selected_1.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    FirstTarget = true;
                }
                clickCount++;
                RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, 60 * clickCount) * transform.up, 0.3f);
                if (hit2 != false)
                {
                    selected_2 = hit2.transform;
                    selected_2.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    SecondTarget = true;
                }
            }
            if (drag)
                ContinueSpin();           
            spinPoint = (selected_1.position + selected_2.position + transform.position) / 3;                     
        }      
    }
    public void OnDrag(PointerEventData data)
    {
        if (spin == false && GameManagerScript.IsInputAvailable&&FirstTarget&&SecondTarget)
        {
            GameManagerScript.IsInputAvailable = false;
            drag = true;          
            ContinueSpin();
        }       
    }
    
    public void ContinueSpin()
    {      
        if (selected_1.gameObject.activeInHierarchy==false)
        {
            spinCount = 0;
            drag = false;
            GameManagerScript.IsInputAvailable = true;
        }
        else
        if (selected_2.gameObject.activeInHierarchy==false)
        {
            spinCount = 0;
            drag = false;
            GameManagerScript.IsInputAvailable = true;
        }
        else if (spinCount == 3)
        {
            spinCount = 0;
            drag = false;
            GameManagerScript.IsInputAvailable = true;
        }
        else
        {
            
            oldColumnNumber0 = gameObject.GetComponent<Blocks>().columnNumber;
            oldColumnNumber1 = selected_1.gameObject.GetComponent<Blocks>().columnNumber;
            oldColumnNumber2 = selected_2.gameObject.GetComponent<Blocks>().columnNumber;
            
            gameObject.GetComponent<Blocks>().columnNumber = oldColumnNumber1;
            selected_1.gameObject.GetComponent<Blocks>().columnNumber = oldColumnNumber2;
            selected_2.gameObject.GetComponent<Blocks>().columnNumber = oldColumnNumber0;

            oldPosition1 = selected_1.position;
            oldPosition0 = transform.position;
            oldPosition2 = selected_2.position;
            spinCount++;
            drag = false;
            

            StartCoroutine(StartSpin());              
        }      
    }
    IEnumerator StartSpin()
    {       
        spin = true;
        yield return new WaitForSeconds(TimeToRotate);
        spin = false;
        selected_1.GetChild(0).localPosition = resetPosition;
        selected_2.GetChild(0).localPosition = resetPosition;
        transform.GetChild(0).localPosition = resetPosition;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        selected_1.localRotation = Quaternion.Euler(0, 0, 0);
        selected_2.localRotation = Quaternion.Euler(0, 0, 0);
       
        selected_1.position =oldPosition2;
     
        selected_2.position =oldPosition0;
       
        transform.position =oldPosition1;
        
        yield return new WaitForSeconds(.2f);
        
        if (continueSpin)
            ContinueSpin();
    }
    public void Update()
    {     
        if (Input.GetButtonDown("Fire1"))
            {
                transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            }              
        if (spin == true)
        {
            selected_1.GetChild(0).RotateAround(spinPoint, transform.forward, 120 * Time.deltaTime);
            selected_2.GetChild(0).RotateAround(spinPoint, transform.forward, 120 * Time.deltaTime);
            transform.GetChild(0).RotateAround(spinPoint, transform.forward, 120 * Time.deltaTime);
        }
    }   
}

