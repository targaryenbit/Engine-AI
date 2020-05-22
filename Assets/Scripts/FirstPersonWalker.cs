﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonWalker : MonoBehaviour
{
    public Vector2 intensidadeRotacao;
    public float vel, deslocamentoAltura;
    public LayerMask camada;
 void FixedUpdate() {
     float mouseX = Input.GetAxis("Mouse X");
     float mouseY = Input.GetAxis("Mouse Y");

    Vector3 rotacao = new Vector3(); 
    rotacao.y = mouseX * intensidadeRotacao.x * Time.deltaTime;
    rotacao.x = -mouseY * intensidadeRotacao.y * Time.deltaTime;
     
     transform.Rotate(rotacao);
    Vector3 rot = transform.eulerAngles;
    rot.z = 0;
    transform.eulerAngles = rot;

    float movH = Input.GetAxis("Horizontal");
    float movV = Input.GetAxis("Vertical");

    Vector3 pos = transform.position;
    transform.Translate(movH * vel * Time.deltaTime, 0, movV * vel * Time.deltaTime);
    RaycastHit hit;
    if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, camada)) {
       pos.y = hit.point.y + deslocamentoAltura ;
    }

    transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
 }
}
