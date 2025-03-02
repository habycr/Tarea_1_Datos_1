using System;

// 1. Abstracción: se define una clase abstracta Personaje que representa una entidad en el juego de rol.
abstract class Personaje
{
    public string Nombre { get; set; }
    public int Nivel { get; set; }
    public int Vida { get; set; }

    public Personaje(string nombre, int nivel, int vida)
    {
        Nombre = nombre;
        Nivel = nivel;
        Vida = vida;
    }

    public abstract void Atacar(); // Método abstracto que será implementado por las subclases, el ataque dependerá de la 
    //clase (del juego, o sea, guerrero, etc). Si es mago, atacará con mana, si es guerrero con fuerza, etc.
}

// 2. Encapsulamiento: la clase guerrero tiene atributos privados y métodos públicos para interactuar con ellos. Sus atributos privados
//(fuerza) están protegidos para evitar modificaciones.
class Guerrero : Personaje
{
    private int fuerza;

    public Guerrero(string nombre, int nivel, int vida, int fuerza) : base(nombre, nivel, vida)
    {
        this.fuerza = fuerza;
    }

    public int GetFuerza()
    {
        return fuerza;
    }

    public void SetFuerza(int nuevaFuerza)
    {
        if (nuevaFuerza > 0)
            fuerza = nuevaFuerza;
    }

    public override void Atacar()
    {
        Console.WriteLine($"{Nombre} ataca con su espada con fuerza {fuerza}!");
    }
}

// 3. Herencia: la clase mago hereda de Personaje y añade un atributo específico, que en su caso es mana.
class Mago : Personaje
{
    private int Mana { get; set; }

    public Mago(string nombre, int nivel, int vida, int mana) : base(nombre, nivel, vida)
    {
        Mana = mana;
    }

    public override void Atacar()
    {
        Console.WriteLine($"{Nombre} lanza un hechizo usando {Mana} de mana!");
    }
}

// 4. Polimorfismo: permite tratar diferentes tipos de personajes de manera uniforme y sin replicaciones.
class Program
{
    static void Main()
    {
        Personaje guerrero = new Guerrero("Garrosh", 10, 100, 20);
        Personaje mago = new Mago("Khadgar", 12, 80, 50);

        guerrero.Atacar(); // Polimorfismo en tiempo de ejecución (override)
        mago.Atacar();
        Console.ReadLine();

    }
}
