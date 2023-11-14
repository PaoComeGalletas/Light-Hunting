using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Esta función se llamará cuando el jugador haga clic en un botón para cerrar el juego.
    public void SalirDelJuego()
    {
        // Salir de la aplicación (solo funciona en builds ejecutables).
        Application.Quit();
    }

    // Esta función se llamará cuando el jugador haga clic en un botón para cambiar de nivel.
    public void CambiarNivel(string nombreDelNivel)
    {
        // Cargar el nuevo nivel por su nombre.
        SceneManager.LoadScene(nombreDelNivel);
    }
}
