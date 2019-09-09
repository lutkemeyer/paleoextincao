﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMenu : MonoBehaviour{

    /*
     * vetor de dinossauros inseridos através
     * do unity
     */
    public GameObject[] personagens;

    /*
     * vetor de peoes inseridos através do
     * unity
     */
    public GameObject[] peoes;

    /*
     * label do título para ser alterado quando
     * o usuário selecionar um dinossauro
     */
    public Text cabecalho;

    /*
     * botão de voltar do menu, para que seja 
     * desativado / ativado quando está selecionando
     * um dino / peão
     */
    public Button btnVoltar;

    /*
     * variáveis que guardam a posição de seleção
     * dos dinossauros / peões
     */
    private int indexPersonagem = 0, indexPeao = 0;

    /* 
     * variável que controla se o usuário
     * está selecionando dinossauros ou peões
     */
    private bool isSelecionandoDino = true;

    /*
     * inicializa a classe tornando o botão de voltar 
     * desabilitado, para ser ativado somente após
     * a seleção de um dino
     */
    void Start() {
        btnVoltar.interactable = false;
    }

    /*
     * método que troca o objeto para o próximo
     * item do vetor, seja ele um dino ou um peão
     */
    public void OnClickDireita() {
        if (isSelecionandoDino) {
            if (indexPersonagem < (personagens.Length - 1)) {
                personagens[indexPersonagem].SetActive(false);
                indexPersonagem++;
                personagens[indexPersonagem].SetActive(true);
            } else {
                personagens[indexPersonagem].SetActive(false);
                indexPersonagem = 0;
                personagens[indexPersonagem].SetActive(true);
            }
        } else {
            if (indexPeao < (peoes.Length - 1)) {
                peoes[indexPeao].SetActive(false);
                indexPeao++;
                peoes[indexPeao].SetActive(true);
            } else {
                peoes[indexPeao].SetActive(false);
                indexPeao = 0;
                peoes[indexPeao].SetActive(true);
            }
        }
    }
    /*
     * método que troca o objeto para item anterior
     * do vetor, seja ele um dino ou um peão
     */
    public void OnClickEsquerda() {
        if (isSelecionandoDino) {
            if (indexPersonagem > 0) {
                personagens[indexPersonagem].SetActive(false);
                indexPersonagem--;
                personagens[indexPersonagem].SetActive(true);
            } else {
                personagens[indexPersonagem].SetActive(false);
                indexPersonagem = personagens.Length - 1;
                personagens[indexPersonagem].SetActive(true);
            }
        } else {
            if (indexPeao > 0) {
                peoes[indexPeao].SetActive(false);
                indexPeao--;
                peoes[indexPeao].SetActive(true);
            } else {
                peoes[indexPeao].SetActive(false);
                indexPeao = peoes.Length - 1;
                peoes[indexPeao].SetActive(true);
            }
        }
    }

    /*
     * Seleciona o peão ou o dino, guardando nas variáveis da classe
     * ou inserindo nas variáveis estáticas para posteriormente trocar de tela 
     * e as mesmas serem possíveis de ser acessadas
     */
    public void OnClickSelecionar() {
        if (isSelecionandoDino) {
            btnVoltar.interactable = true;
            isSelecionandoDino = false;
            personagens[indexPersonagem].SetActive(false);
            peoes[indexPeao].SetActive(true);
            cabecalho.text = "ESCOLHA SEU PEÃO";
        } else {
            ControladorCenas.addParametro(ControladorCenas.PERSONAGEM, indexPersonagem);
            ControladorCenas.addParametro(ControladorCenas.PEAO, indexPeao);
            ControladorCenas.carregaCena(ControladorCenas.CENA_JOGO);
        }
    }
    
    /*
     * volta a opção de seleção de peão para dino, desativando o botão
     */
    public void OnClickVoltar() {
        cabecalho.text = "ESCOLHA SEU PERSONAGEM";
        btnVoltar.interactable = false;
        isSelecionandoDino = true;
        peoes[indexPeao].SetActive(false);
        personagens[indexPersonagem].SetActive(true);
    }
}
