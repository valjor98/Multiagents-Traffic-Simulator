using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class jsonDataClass
{
    public List<vehiculoCarroDer> CarroDerecha;
    public List<vehiculoCarroIzq> CarroIzquierda;
    public List<vehiculoCarroArr> CarroArriba;
    public List<vehiculoCarroAba> CarroAbajo;
}

[Serializable]
public class vehiculoCarroDer
{
    public float pos_Carro_der_x;
    public float pos_Carro_der_y;
    public String tipo;
    public int ID_Carro_der;
}

[Serializable]
public class vehiculoCarroIzq
{
    public float pos_Carro_izq_x;
    public float pos_Carro_izq_y;
    public String tipo;
    public int ID_Carro_izq;
}

[Serializable]
public class vehiculoCarroArr
{
    public float pos_Carro_arr_x;
    public float pos_Carro_arr_y;
    public String tipo;
    public int ID_Carro_arr;
}

[Serializable]
public class vehiculoCarroAba
{
    public float pos_Carro_aba_x;
    public float pos_Carro_aba_y;
    public String tipo;
    public int ID_Carro_aba;
}