using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour //mks
{
GameObject plyr_loc;
int height;
private float time;
public float pltfrm_size;
public string goup_fnct;
//possible goleft_fnct for 3d platform movement
//possible gofrwrd_fnct
public float maxtimeup;
public string godwn_fnct;
// same as higher
public float maxtimedwn;
void Awake() 
{
plyr_loc= GameObject.Find("Player");
height=1;
}

void Update () 
{
    if (height==1 || height==4){
    if(Vector3.Distance(transform.position,plyr_loc.transform.position)<pltfrm_size-0.15) {
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
   //here is good place to set the plaftorm to original position, unless we want it to change location after 9999999 uses
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
time+=Time.deltaTime;
transform.position+=new Vector3(0f,Time.deltaTime*strng_t_nbmr(goup_fnct,time),0f);
if (time>=maxtimeup) {height=4;}
}

void movedown()
{
time+=Time.deltaTime;
transform.position+=new Vector3(0f,-Time.deltaTime*strng_t_nbmr(goup_fnct,time),0f);
if (time>=maxtimedwn) {height=1;}
}

private float strng_t_nbmr(string strng_fnct,float timex)
{
   strng_fnct = strng_fnct.Replace("x", timex.ToString());
   strng_fnct=strng_fnct.Replace(",",".");
   ExpressionEvaluator.Evaluate(strng_fnct, out float result);
   return(result);
}

}