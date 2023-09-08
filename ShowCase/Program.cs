using UtilityLibraries;
using EspacioCadeteria;

class program{
    static void Main(string[] args){
        libreriaCadeteria Cadeteria1;
        string nombre = "Nombre de la cadeteria";
        long telefono = 3483284;
        Cadeteria1 = new libreriaCadeteria(nombre, telefono);
        Cadeteria1.cargarCadetes(1);
        Cadeteria1.mostrarDatosCadete();
    }
}