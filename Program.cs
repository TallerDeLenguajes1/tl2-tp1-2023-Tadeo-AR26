using EspacioCadeteria;

Cadeteria cadeteria;
long telefono = 5491123900033;
cadeteria = new Cadeteria("PedidosYa", telefono);
string archivo = "Cadetes.csv";
cadeteria.AgregarCadete(1, "Tadeo", "Av.", telefono);
