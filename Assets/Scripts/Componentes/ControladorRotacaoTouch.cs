﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Componente responsável por controlar a ação de clicar e arrastar no touch
 * do usuário, fazendo o objeto atrelado girar
 */
public class ControladorRotacaoTouch : MonoBehaviour
{
    /* 
     * velocidade relativa ao tamanho da rotação que o 
     * objeto fará em relação ao movimento do touch
     */
    public float velocidade;

    /* 
     * suavidade referente a quando a pessoa solta o 
     * touch e ele desascelera
     */
    public float suavidade;

    /* 
     * QR = QuaternionRotate
     * variáveis referente a posição do objeto que está
     * girando
     * from = posição atual do objeto
     * to = ponde ele deverá ir (calculado com o movimento de touch)
     */
    private Quaternion QRfrom, QRto;

    /*
     * Variável de controle para adição de mais movimentos a cada toque
     * na tela
     */
    private float valorMovimento;

    /*
     * Controlador do touch, classe que gerencia toques e arrasto de tocuh
     * de forma mais adequada ao problema em questão, deve ser atualizada
     * todas as vezes que se deseja obter uma informação
     */
    private AcelerometroTouch acelerometro = new AcelerometroTouch();

    /*
     * Função que utiliza as informações capturadas pelo acelerometro
     * e atualiza o giro dos objetos controlados por esta classe
     */
    void Update() {
        acelerometro.atualiza(); 
        float distAcel = acelerometro.getDistNorm();
        if (acelerometro.getDir() == AcelerometroTouch.Direcao.DIREITA) distAcel = distAcel * (-1);
        valorMovimento += (distAcel * 10) * velocidade;
        QRfrom = transform.rotation;
        QRto = Quaternion.Euler(0, valorMovimento, 0);
        transform.rotation = Quaternion.Lerp(QRfrom, QRto, Time.deltaTime * suavidade);
    }
}
