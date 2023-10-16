using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour //mks
{
GameObject plyr_loc;
int height;
private float time;
public float maxtimeup;
public float maxtime;
public string goup_fnct;
public string godwn_fnct;
void Awake() 
{
plyr_loc= GameObject.Find("Player");
height=1;
}

void Update () 
{
    if (height==1 || height==4){
    if(Vector3.Distance(transform.position,plyr_loc.transform.position)<0.85f) {
    elevatii();}}
}
void FixedUpdate()
{
    if (height==2){moveup();}
    else if (height==3) {movedown();}
}

void elevatii()
{
 if (height==1) {
    height=2;
    time=0f;
 }
 else if (height==4) {
    height=3;
    time=0f;
 }
}

void moveup()
{
Debug.Log("moving up");
time+=Time.deltaTime;
transform.position+=new Vector3(0f,Time.deltaTime*strng_t_nbmr(goup_fnct,time),0f);
if (time>=maxtime) {height=4;}
}

void movedown()
{
Debug.Log("moving down");
time+=Time.deltaTime;
transform.position+=new Vector3(0f,-Time.deltaTime*strng_t_nbmr(goup_fnct,time),0f);
if (time>=maxtime) {height=1;}
}

private float strng_t_nbmr(string govert,float timex)
{
   govert = govert.Replace("x", timex.ToString());
   govert=govert.Replace(",",".");
   ExpressionEvaluator.Evaluate(govert, out float result);
   return(result);
}

}