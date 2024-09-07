const string codigoFinDeCompra = "FIN";



const string codigoDesodorante = "DES";

const string codigoJabonEnPolvo = "JP";

const string codigoDetergente = "DET";



string codigoProductoSeleccionado;

int montoTotal = 0;



Console.WriteLine("Bienvenidos a mi Tienda... ");



codigoProductoSeleccionado = ObtenerCodigoDeProducto();



while (!FinDeCompra(codigoProductoSeleccionado, codigoFinDeCompra))

{

    montoTotal += CalculoMontoProducto(codigoProductoSeleccionado);

    codigoProductoSeleccionado = ObtenerCodigoDeProducto();

}



Console.WriteLine($"El monto total de su compra es {montoTotal}");



if (ConfirmarCompra())

{

    Console.WriteLine("Gracias por comprar en nuestra tienda!!");

}

else

{

    Console.WriteLine("Su compra ha sido cancelada, el sistema se cerrara...");

}

string ObtenerCodigoDeProducto()

{

    Console.WriteLine("Ingrese el código del producto:");

    string codigo = Console.ReadLine();

    while (!CodigosSonIguales(codigo, codigoDesodorante)

    && !CodigosSonIguales(codigo, codigoJabonEnPolvo)

    && !CodigosSonIguales(codigo, codigoDetergente)

    && !CodigosSonIguales(codigo, codigoFinDeCompra))

    {

        Console.WriteLine("Código invalido, intente nuevamente");

        codigo = Console.ReadLine();

    }

    return codigo.ToUpper();

}



bool FinDeCompra(string codigoSeleccionado, string codigoFinDeCompra)

{

    return CodigosSonIguales(codigoSeleccionado, codigoFinDeCompra);

}



bool CodigosSonIguales(string codigoSeleccionado, string codigoFinDeCompra)

{

    return codigoFinDeCompra.Equals(codigoSeleccionado, StringComparison.InvariantCultureIgnoreCase);

}

bool ConfirmarCompra()

{

    const string SI = "SI";

    const string NO = "NO";

    Console.WriteLine("Está seguro/a que quiere realizar la compra (SI/NO)?");

    string respuesta = Console.ReadLine();

    while (!CodigosSonIguales(respuesta, SI) && !CodigosSonIguales(respuesta, NO))

    {

        Console.WriteLine("Respuesta inválida, intente nuevamente");

        respuesta = Console.ReadLine();

    }

    return CodigosSonIguales(respuesta, SI);

}

int PreguntarCantidad()

{

    Console.WriteLine("Cuántos productos comprará?");

    bool esEntero = int.TryParse(Console.ReadLine(), out int cantidad);

    while (!esEntero || cantidad <= 0)

    {

        Console.WriteLine("Valor no válido, intente nuevamente");

        esEntero = int.TryParse(Console.ReadLine(), out cantidad);

    }

    return cantidad;

}

int CalculoMontoProducto(string codigoProductoSeleccionado)

{

    int cantidad = PreguntarCantidad();

    //int precioProducto; 

    //switch (codigoProductoSeleccionado) 

    // { 

    // case codigoDesodorante: 

    // precioProducto = 200; 

    // break; 

    // case codigoJabonEnPolvo: 

    // precioProducto = 300; 

    // break; 

    // case codigoDetergente: 

    // precioProducto = 250; 

    // break; 

    // default: 

    // precioProducto = 0; 

    // break; 

    //} 

    int precioProducto = codigoProductoSeleccionado switch

    {

        codigoDesodorante => 200,

        codigoJabonEnPolvo => 300,

        codigoDetergente => 250,

        _ => 0,

    };

    return precioProducto * cantidad;

}