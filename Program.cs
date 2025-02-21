using System;

public class MenuConsola
{
    public static void Main(string[] args)
    {
        int opcion = 0;
        do
        {
            MostrarMenu();
            if
               (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Calculadora();
                        break;
                    case 2:
                        ValidarContraseña();
                        break;
                    case 3:
                        numerosprimos();
                        break;
                    case 4:
                        sumapar();
                        break;
                    case 5:
                        conversionTemperatura();
                        break;
                    case 6:
                        contadorvocales();
                        break;
                    case 7:
                        calculofactorial();
                        break;
                    case 8:
                        juegoadivinanza();
                        break;
                    case 9:
                        pasoreferencia();
                        break;
                    case 10:
                        tablamultiplicar();
                        break;
                    case 11:
                        Console.WriteLine("Saliendo del Programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no Válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no Válida, Ingrese otro Número.");
            }
            Console.WriteLine();
        } while (opcion != 11);
    }
    static void MostrarMenu()
    {
        Console.WriteLine("1.  Calculadora básica.");
        Console.WriteLine("2.  Validación de Contraseña.");
        Console.WriteLine("3.  Números Primos.");
        Console.WriteLine("4.  Suma de números pares.");
        Console.WriteLine("5.  Conversión de Temperatura.");
        Console.WriteLine("6.  Contador de Vocales.");
        Console.WriteLine("7.  Calculo de Factorial.");
        Console.WriteLine("8.  Juego de Adivinanza.");
        Console.WriteLine("9.  Paso por Referencia.");
        Console.WriteLine("10. Tabla de Multiplicar.");
        Console.WriteLine("11. Salir.");
        Console.WriteLine("Ingrese una opción.");
    }
    static void Calculadora()
    {
        Console.WriteLine("Calculadora básica:");
        double num1 = ObtenerNumero("Ingrese el primer número:");
        double num2 = ObtenerNumero("Ingrese el segundo número:");
        char operacion = ObtenerOperacion();
        double resultado = Calcular(num1, num2, operacion);
        Console.WriteLine("El resultado es: " + resultado);
    }

    static double ObtenerNumero(string mensaje)
    {
        double numero;
        bool valido = false;
        do
        {
            Console.WriteLine(mensaje);
            string input = Console.ReadLine();
            valido = double.TryParse(input, out numero);
            if (!valido)
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        } while (!valido);
        return numero;
    }

    static char ObtenerOperacion()
    {
        char operacion;
        bool valida = false;
        do
        {
            Console.WriteLine("Ingrese la operación (+, -, *, /):");
            string input = Console.ReadLine();
            if (input.Length == 1 && "+-*/".Contains(input[0]))
            {
                operacion = input[0];
                valida = true;
            }
            else
            {
                Console.WriteLine("Operación no válida. Por favor, ingrese +, -, * o /.");
                operacion = '\0';
            }
        } while (!valida);
        return operacion;
    }

    static double Calcular(double a, double b, char operacion)
    {
        switch (operacion)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    Console.WriteLine("No se puede dividir por cero.");
                    return double.NaN;
                }
                return a / b;
            default:
                return double.NaN;
        }
    }

    static void ValidarContraseña()
    {
        Console.WriteLine("Validación de contraseña:");
        string contrasena;
        do
        {
            Console.Write("Ingrese la contraseña: ");
            contrasena = Console.ReadLine();
            if (contrasena != "1234")
            {
                Console.WriteLine("Contraseña incorrecta. Intente de nuevo.");
            }
        } while (contrasena != "1234");
        Console.WriteLine("Acceso concedido.");
    }

    static void numerosprimos()
    {
        Console.WriteLine("Números primos:");
        int numero = ObtenerEntero("Ingrese un número entero:");
        if (EsPrimo(numero))
        {
            Console.WriteLine(numero + " es primo.");
        }
        else
        {
            Console.WriteLine(numero + " no es primo.");
        }
    }

    static int ObtenerEntero(string mensaje)
    {
        int numero;
        bool valido = false;
        do
        {
            Console.WriteLine(mensaje);
            string input = Console.ReadLine();
            valido = int.TryParse(input, out numero);
            if (!valido)
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
        } while (!valido);
        return numero;
    }

    static bool EsPrimo(int numero)
    {
        if (numero <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void sumapar()
    {
        Console.WriteLine("Suma de números pares:");
        int numero;
        int suma = 0;
        do
        {
            numero = ObtenerEntero("Ingrese un número entero (0 para terminar):");
            if (numero % 2 == 0)
            {
                suma += numero;
            }
        } while (numero != 0);
        Console.WriteLine("La suma de los números pares es: " + suma);
    }

    static void conversionTemperatura()
    {
        Console.WriteLine("Conversión de temperatura:");
        Console.WriteLine("1. Celsius a Fahrenheit");
        Console.WriteLine("2. Fahrenheit a Celsius");
        int opcion = ObtenerEntero("Ingrese una opción:");
        if (opcion == 1)
        {
            double celsius = ObtenerNumero("Ingrese la temperatura en Celsius:");
            ConvertirCelsiusAFahrenheit(celsius, out double fahrenheit);
            Console.WriteLine(celsius + " grados Celsius son " + fahrenheit + " grados Fahrenheit.");
        }
        else if (opcion == 2)
        {
            double fahrenheit = ObtenerNumero("Ingrese la temperatura en Fahrenheit:");
            ConvertirFahrenheitACelsius(fahrenheit, out double celsius);
            Console.WriteLine(fahrenheit + " grados Fahrenheit son " + celsius + " grados Celsius.");
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }

    static void ConvertirCelsiusAFahrenheit(double celsius, out double fahrenheit)
    {
        fahrenheit = (celsius * 9 / 5) + 32;
    }

    static void ConvertirFahrenheitACelsius(double fahrenheit, out double celsius)
    {
        celsius = (fahrenheit - 32) * 5 / 9;
    }
    static void contadorvocales()
    {
        Console.WriteLine("Contador de vocales:");
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();
        int cantidadVocales = ContarVocales(frase);
        Console.WriteLine("La frase contiene " + cantidadVocales + " vocales.");
    }

    static int ContarVocales(string texto)
    {
        int contador = 0;
        string vocales = "aeiouAEIOU";
        foreach (char letra in texto)
        {
            if (vocales.Contains(letra))
            {
                contador++;
            }
        }
        return contador;
    }
    static void calculofactorial()
    {
        Console.WriteLine("Ingrese número positivo: ");
        if
            (int.TryParse(Console.ReadLine(), out int num) && num >= 0)
        {
            long resultado = Factorial(num);
            Console.WriteLine("El factorial de " + num + " es " + resultado);
        }
        else
        {
            Console.WriteLine("Inválido");
        }
    }
    static long Factorial(int num)
    {
        long factorial = 1;
        for (int i = 1; i <= num; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
    static void juegoadivinanza()
    {
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 11);
            int intento;
            do
            {
                Console.Write("Adivina el número entre 1 y 10: ");
                if (int.TryParse(Console.ReadLine(), out intento))
                {
                    if (intento < numeroSecreto)
                    {
                        Console.WriteLine("Demasiado bajo.");
                    }
                    else if (intento > numeroSecreto)
                    {
                        Console.WriteLine("Demasiado alto.");
                    }
                    else
                    {
                        Console.WriteLine("¡Correcto!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }
            } while (true);
        }
    }
    static void pasoreferencia()
    {
        Console.Write("Ingrese el primer número: ");
        if (!int.TryParse(Console.ReadLine(), out int num1))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        Console.Write("Ingrese el segundo número: ");
        if (!int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        Console.WriteLine("Valores originales: num1 = " + num1 + ", num2 = " + num2);
        Intercambiar(ref num1, ref num2);
        Console.WriteLine("Valores intercambiados: num1 = " + num1 + ", num2 = " + num2);
    }

    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }


    static void tablamultiplicar()
    {
        Console.Write("Ingrese un número: ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            multiplicar(num);
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }
    }

    static void multiplicar(int n)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(n + " x " + i + " = " + (n * i));
        }
    }


}



