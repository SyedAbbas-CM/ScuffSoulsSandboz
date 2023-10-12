using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour //mks
{
GameObject plyr_loc;
int height;
private float time;
public float maxtime;

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

    else if (height==2){moveup();}
    else {movedown();}
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
transform.position+=new Vector3(0f,Time.deltaTime,0f);
if (time>=maxtime) {height=4;}
}

void movedown()
{
Debug.Log("moving down");
time+=Time.deltaTime;
transform.position+=new Vector3(0f,-Time.deltaTime,0f);
if (time>=maxtime) {height=1;}
}
}