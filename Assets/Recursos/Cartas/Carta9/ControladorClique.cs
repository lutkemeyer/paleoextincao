﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorClique : MonoBehaviour{

    public GameObject[] objetos;
    public Sprite[] imagens;

    private RepositorioConteudo repositorioConteudo;
    private GameObject pnDinossauro;

    void Start(){
        pnDinossauro = GameObject.FindGameObjectWithTag("PnDinossauro");
        repositorioConteudo = new RepositorioConteudo(imagens);
    }
    void Update(){
        if(!pnDinossauro.GetComponent<AnimadorAbrirFechar>().isAberto()) {
            
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    string nome = hit.transform.name;
                    for (int i = 0; i < objetos.Length; i++) {
                        if (objetos[i].name.Equals(nome)) {
                            funcao(i);
                        }
                    }
                }
            }
            
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    string nome = hit.transform.name;
                    for (int i = 0; i < objetos.Length; i++) {
                        if (objetos[i].name.Equals(nome)) {
                            funcao(i);
                        }
                    }
                }
            }
        }
    }
    public void funcao(int index) {
        setGeneroDinossauro(repositorioConteudo.get(index));
        pnDinossauro.GetComponent<AnimadorAbrirFechar>().abrir();
        GameObject.FindGameObjectWithTag("PnDinossauro").GetComponent<AnimadorAbrirFechar>().abrir();
    }
    public void setGeneroDinossauro(GeneroDinossauro dinossauro){
        GameObject.FindGameObjectWithTag("ImgDinossauro").GetComponent<Image>().sprite = dinossauro.getSprite();
        GameObject.FindGameObjectWithTag("TxtGenero").GetComponent<Text>().text = dinossauro.getNomeGenero().ToUpper();
        GameObject.FindGameObjectWithTag("TxtFamilia").GetComponent<Text>().text = dinossauro.getFamilia().ToUpper();
        GameObject.FindGameObjectWithTag("TxtDescricao").GetComponent<TextMeshProUGUI>().text = dinossauro.getDescricao();
    }
}
