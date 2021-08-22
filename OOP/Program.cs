using System;
using Clientes;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cliente  = new Cliente("Johne", "2199903437", "13991590323");
            cliente.Gravar();
            var clientes = Cliente.LerClientes();
        }
    }
}
