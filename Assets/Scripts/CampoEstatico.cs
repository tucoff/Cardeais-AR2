using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CampoEstatico : MonoBehaviour
{
    public GameObject campo;
    public Material mat;
    bool created = false;

    // Método responsável por criar um campo estático
    public void CreateAStaticField()
    {
        // Verifica se o campo já foi criado
        if(!created)
        {    
            // Instancia um novo campo que não se move
            GameObject newCampo = Instantiate(campo, this.transform);
            newCampo.transform.position = campo.transform.position;
            newCampo.transform.localRotation = campo.transform.parent.localRotation;
            newCampo.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
            newCampo.transform.GetChild(1).GetComponent<MeshRenderer>().material = mat;
            campo.transform.gameObject.SetActive(false);
            created = true;
        }
    }
}
