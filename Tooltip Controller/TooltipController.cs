using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TooltipController : MonoBehaviour
{
    // Controlador da UI, onde o elemento do tooltip deve estar
    // referenciado
    private UIController UI_Controller;

    // Evento de pressionamento de botão
    public UnityEvent OnPressEvent;

    // Texto base do tooltip
    [SerializeField] private string tooltipBaseText = "<default tooltip>";

    // Texto atual do tooltip (caso precise mudar o texto)
    private string tooltipCurrentText = "";

    // Texto da tecla de pressionamento
    [SerializeField] private string tooltipKey = "";

    // Booleana de controle para execução ou não do evento
    private bool canPressButton = false;

    private void Awake ()
    {
        // Incializa o texto do tooltip
        tooltipCurrentText = tooltipBaseText;
        // Atrela o controlador de UI ao código (modificar para seu projeto)
        UI_Controller = GameObject.Find("UI").GetComponent<UIController>();
    }

    private void Start ()
    {
        /* Caso esteja usando um InputHandler a base de eventos, utilize este código
        tooltipKey = "[" + InputHandler.current.interactionKey.ToString().ToUpper() + "]";
        InputHandler.current.OnInteractionPressed += ButtonPressed;
        */    
    }

    private void ButtonPressed (object sender, EventArgs e)
    {
        // Se pode apertar o botão, invoque o evento do tooltip
        if (canPressButton)
        {
            OnPressEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Se o objeto com a tag "Player" estiver dentro
            // do collider (área de interação) do tooltip,
            // o permita apertar o botão
            canPressButton = true;
            // Mostre o texto do tooltip
            ShowText();
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Se o objeto com a tag "Player" sair do
            // do collider (área de interação) do tooltip,
            // não o permita apertar o botão
            canPressButton = false;
            // Esconda o texto do tooltip
            HideText();
        }
    }

    private void OnDestroy ()
    {
        /* Caso esteja usando um InputHandler a base de eventos, utilize este código
        InputHandler.current.OnInteractionPressed -= ButtonPressed;
        */    
    }

    public void ChangeText (string text)
    {
        // Altera o texto do tooltip
        tooltipCurrentText = text;
    }

    public void ShowText ()
    {
        // Exibe o elemento de UI referente ao tooltip com a tecla de interação
        // (modificar para seu projeto)
        UI_Controller.DrawTooltip(tooltipCurrentText + " " + tooltipKey);
    }

    public void ShowTextWihtoutKey ()
    {
        // Exibe o elemento de UI referente ao tooltip sem a tecla de interação 
        // (modificar para seu projeto)
        UI_Controller.DrawTooltip(tooltipCurrentText);
    }

    public void HideText ()
    {
        // Esconda o elemento de UI referente ao tooltip 
        // (modificar para seu projeto)
        UI_Controller.HideTooltip();
    }
    
    public string GetTooltipBaseText () => tooltipBaseText;

    public string GetTooltipCurrentText () => tooltipCurrentText;
}
