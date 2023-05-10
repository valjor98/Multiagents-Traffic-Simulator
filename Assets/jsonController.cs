using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class jsonController : MonoBehaviour
{
    public string jsonURL;
    public List<Vector3> posCarro_Der;
    public List<Vector3> posCarro_Izq;
    public List<Vector3> posCarro_Arr;
    public List<Vector3> posCarro_Aba;
    public float speed = 2;
    public double x_prov, z_prov;
    public GameObject CarroDerechaObj, CarroIzquierdaObj, CarroArribaObj, CarroAbajoObj;



    // Start is called before the first frame update
    void Start()
    {
        CarroDerechaObj = GameObject.FindGameObjectWithTag("CarroDerecha");
        CarroIzquierdaObj = GameObject.FindGameObjectWithTag("CarroIzquierda");
        CarroArribaObj = GameObject.FindGameObjectWithTag("CarroArriba");
        CarroAbajoObj = GameObject.FindGameObjectWithTag("CarroAbajo");

        CarroDerechaObj.transform.position = new Vector3((float)-125, 70, 104);
        CarroIzquierdaObj.transform.position = new Vector3((float)126.5, 70, 430);
        CarroArribaObj.transform.position = new Vector3(-22, 70, 14);
        CarroAbajoObj.transform.position = new Vector3(215, 70, (float)-15.625);
        
        //processJsonData(jsonURL);
        StartCoroutine(getData());

    }

    IEnumerator getData(){
        Debug.Log("Processing Data");
        int counter = 0;
        while(counter < 100 ){
            WWW _www = new WWW(jsonURL);
            yield return _www;
            if(_www.error == null){
                processJsonData(_www.text);
            }
            else{
                Debug.Log("Oops something went wrong");
            }
            yield return new WaitForSeconds(1);            
        }
    }

    // Update is called once per frame
    private void processJsonData(string _url)
    {
        jsonDataClass jsData = JsonUtility.FromJson<jsonDataClass>(_url);

        
        float step = speed * Time.deltaTime;

        foreach(vehiculoCarroDer x in jsData.CarroDerecha){
            if(0 <= x.pos_Carro_der_y && x.pos_Carro_der_y < 7){
                x_prov = 15 * x.pos_Carro_der_y  - 125;

            }
            else if(7 <= x.pos_Carro_der_y && x.pos_Carro_der_y < 15){
                x_prov = 4.375 * x.pos_Carro_der_y - 50.625;

            }
            else if(15 <= x.pos_Carro_der_y && x.pos_Carro_der_y < 44){
                x_prov = 11*x.pos_Carro_der_y - 150;

            }
            else if(44 <= x.pos_Carro_der_y && x.pos_Carro_der_y < 52){
                x_prov = 5.125*x.pos_Carro_der_y + 108.5;
            }
            else{
                x_prov = 11*x.pos_Carro_der_y - 197;
            }



            if(0 <= x.pos_Carro_der_x && x.pos_Carro_der_x < 14){
                z_prov = -6 * x.pos_Carro_der_x + 215;
            }
            else if(14 <= x.pos_Carro_der_x && x.pos_Carro_der_x < 22){
                z_prov = -4.5*x.pos_Carro_der_x + 194;
            }
            else{
                z_prov = -9 * x.pos_Carro_der_x + 293;
            }


            //posCarro_Der.Add(new Vector3(x.pos_Carro_der_x, x.pos_Carro_der_y, 0)); 

        }
        //CarroDerechaObj.transform.position = Vector3.MoveTowards(transform.position, new Vector3((float)x_prov, 70, (float)z_prov), step);
        CarroDerechaObj.transform.position = new Vector3((float)x_prov, 70, (float)z_prov);

        foreach(vehiculoCarroIzq x in jsData.CarroIzquierda){
            if(0 <= x.pos_Carro_izq_y && x.pos_Carro_izq_y < 7){
                x_prov = 15 * x.pos_Carro_izq_y  - 125;
            }
            else if(7 <= x.pos_Carro_izq_y && x.pos_Carro_izq_y < 15){
                x_prov = 4.375*x.pos_Carro_izq_y - 50.625;
            }
            else if(15 <= x.pos_Carro_izq_y && x.pos_Carro_izq_y < 44){
                x_prov = 11*x.pos_Carro_izq_y - 150;
            }
            else if(44 <= x.pos_Carro_izq_y && x.pos_Carro_izq_y < 52){
                x_prov = 5.125*x.pos_Carro_izq_y + 108.5;
            }
            else{
                x_prov = 11*x.pos_Carro_izq_y - 197;
            }



            if(0 <= x.pos_Carro_izq_x && x.pos_Carro_izq_x < 14){
                z_prov = -6 * (x.pos_Carro_izq_x+1) + 215;
            }
            else if(14 <= x.pos_Carro_izq_x && x.pos_Carro_izq_x < 22){
                z_prov = -4.5*(x.pos_Carro_izq_x+1) + 194;
            }
            else{
                z_prov = -9 * (x.pos_Carro_izq_x+1) + 293;
            }


            //posCarro_Izq.Add(new Vector3(x.pos_Carro_izq_x, x.pos_Carro_izq_y, 0));  
        }
        //CarroIzquierdaObj.transform.position = Vector3.MoveTowards(transform.position, new Vector3((float)x_prov, 70, (float)z_prov), step);
        CarroIzquierdaObj.transform.position = new Vector3((float)x_prov, 70, (float)z_prov);

        foreach(vehiculoCarroArr x in jsData.CarroArriba){
            if(0 <= x.pos_Carro_arr_y && x.pos_Carro_arr_y < 7){
                x_prov = 15 * x.pos_Carro_arr_y  - 125;
            }
            else if(7 <= x.pos_Carro_arr_y && x.pos_Carro_arr_y < 15){
                x_prov = 4.375*x.pos_Carro_arr_y - 50.625;
            }
            else if(15 <= x.pos_Carro_arr_y && x.pos_Carro_arr_y < 44){
                x_prov = 11*x.pos_Carro_arr_y - 150;
            }
            else if(44 <= x.pos_Carro_arr_y && x.pos_Carro_arr_y < 52){
                x_prov = 5.125*x.pos_Carro_arr_y + 108.5;
            }
            else{
                x_prov = 11*x.pos_Carro_arr_y - 197;
            }



            if(0 <= x.pos_Carro_arr_x && x.pos_Carro_arr_x < 14){
                z_prov = -6 * x.pos_Carro_arr_x + 215;
            }
            else if(14 <= x.pos_Carro_arr_x && x.pos_Carro_arr_x < 22){
                z_prov = -4.5*x.pos_Carro_arr_x + 194;
            }
            else{
                z_prov = -9 * x.pos_Carro_arr_x + 293;
            }

            //posCarro_Arr.Add(new Vector3(x.pos_Carro_arr_x, x.pos_Carro_arr_y, 0)); 
        }
        //Vector3 target = new Vector3((float)x_prov, 70, (float)z_prov);
        //CarroArribaObj.transform.position = Vector3.MoveTowards(transform.position, target, step);

        CarroArribaObj.transform.position = new Vector3((float)x_prov, 70, (float)z_prov);


        foreach(vehiculoCarroAba x in jsData.CarroAbajo){
            //posCarro_Aba.Add(new Vector3(x.pos_Carro_aba_x, x.pos_Carro_aba_y, 0));  
            if(0 <= x.pos_Carro_aba_y && x.pos_Carro_aba_y < 7){
                x_prov = 15 * x.pos_Carro_aba_y  - 125;
            }
            else if(7 <= x.pos_Carro_aba_y && x.pos_Carro_aba_y < 15){
                x_prov = 4.375*x.pos_Carro_aba_y - 50.625;
            }
            else if(15 <= x.pos_Carro_aba_y && x.pos_Carro_aba_y < 44){
                x_prov = 11*x.pos_Carro_aba_y - 150;
            }
            else if(44 <= x.pos_Carro_aba_y && x.pos_Carro_aba_y < 52){
                x_prov = 5.125*x.pos_Carro_aba_y + 108.5;
            }
            else{
                x_prov = 11*x.pos_Carro_aba_y - 197;
            }



            if(0 <= x.pos_Carro_aba_x && x.pos_Carro_aba_x  < 14){
                z_prov = -6 * x.pos_Carro_aba_x + 215;
            }
            else if(14 <= x.pos_Carro_aba_x && x.pos_Carro_aba_x  < 22){
                z_prov = -4.5*x.pos_Carro_aba_x + 194;
            }
            else{
                z_prov = -9 * x.pos_Carro_aba_x + 293;
            }
        }
        //CarroAbajoObj.transform.position = Vector3.MoveTowards(transform.position, new Vector3((float)x_prov, 70, (float)z_prov), step);
        CarroAbajoObj.transform.position = new Vector3((float)x_prov, 70, (float)z_prov);
    }
}
