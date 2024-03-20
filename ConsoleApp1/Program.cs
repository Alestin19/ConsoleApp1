using System;
using System.Collections.Generic;
using System.Threading;

public class Banco
{
    private Dictionary<string, Dictionary<string, double>> usuarios;
    private Dictionary<string, double> tasasInteres;
    private Random random; // Se añade una instancia de Random para generar números aleatorios.

    public Banco()
    {
        usuarios = new Dictionary<string, Dictionary<string, double>>();
        tasasInteres = new Dictionary<string, double>()
        {
            { "ahorro", 0.02 },
            { "corriente", 0.01 }
        };
        random = new Random(); // Se inicializa la instancia de Random.
    }

    public string CrearCuenta(string nombre, string tipoCuenta)
    {
        // Simulamos una latencia aleatoria de 1 a 3 segundos
        Thread.Sleep(random.Next(1000, 3000));

        // Verificamos si el usuario ya existe
        if (usuarios.ContainsKey(nombre))
        {
            return $"El usuario {nombre} ya tiene una cuenta.";
        }

        // Verificamos si el tipo de cuenta es válido
        if (!tasasInteres.ContainsKey(tipoCuenta))
        {
            return "Tipo de cuenta no válido.";
        }

        // Creamos la cuenta
        usuarios[nombre] = new Dictionary<string, double>
        {
            { "saldo", 0 },
            { "tipoCuenta", tasasInteres[tipoCuenta] }
        };

        return $"Cuenta creada con éxito para {nombre}.";
    }

    public string ConsultarTasaInteres(string tipoCuenta)
    {
        // Simulamos una latencia aleatoria de 1 a 3 segundos
        Thread.Sleep(random.Next(1000, 3000));

        if (tasasInteres.ContainsKey(tipoCuenta))
        {
            return $"Tasa de interés para la cuenta {tipoCuenta}: {tasasInteres[tipoCuenta] * 100}%";
        }
        else
        {
            return "Tipo de cuenta no válido.";
        }
    }

    public string BloquearCuenta(string nombre)
    {
        // Simulamos una latencia aleatoria de 1 a 3 segundos
        Thread.Sleep(random.Next(1000, 3000));

        if (usuarios.ContainsKey(nombre))
        {
            usuarios.Remove(nombre);
            return $"Cuenta de {nombre} bloqueada correctamente.";
        }
        else
        {
            return $"No se encontró la cuenta de {nombre}.";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Banco banco = new Banco();

        // Crear cuentas de ejemplo
        Console.WriteLine(banco.CrearCuenta("Usuario1", "ahorro"));
        Console.WriteLine(banco.CrearCuenta("Usuario2", "corriente"));
        Console.WriteLine(banco.CrearCuenta("Usuario3", "ahorro"));

        // Consultar tasas de interés
        Console.WriteLine(banco.ConsultarTasaInteres("ahorro"));
        Console.WriteLine(banco.ConsultarTasaInteres("corriente"));

        // Bloquear una cuenta de ejemplo
        Console.WriteLine(banco.BloquearCuenta("Usuario1"));
    }
}
