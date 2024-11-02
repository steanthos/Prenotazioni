class Program
{
    static void Main()
    {
        var sistemaNoleggio = new SistemaNoleggio();
        sistemaNoleggio.CaricaNoleggi();

        while (true)
        {
            Console.WriteLine("Scegli un'operazione:");
            Console.WriteLine("1. Aggiungi noleggio");
            Console.WriteLine("2. Visualizza tutti i noleggi");
            Console.WriteLine("3. Cerca noleggio per nome cliente");
            Console.WriteLine("4. Modifica durata noleggio");
            Console.WriteLine("5. Termina noleggio");
            Console.WriteLine("6. Esci e salva");
            Console.WriteLine("-------------");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il nome del cliente: ");
                    string nomeCliente = Console.ReadLine();

                    Console.Write("Inserisci il modello dell'auto: ");
                    string modelloAuto = Console.ReadLine();

                    int durataGiorni;
                    do
                    {
                        Console.WriteLine("Inserisci la durata del noleggio (in giorni): ");
                        string inputDurata = Console.ReadLine();

                        if (!int.TryParse(inputDurata, out durataGiorni) || durataGiorni <= 0)
                        {
                            Console.WriteLine("Durata non valida, inserire numero intero positivo.");
                        }
                    }
                    while (durataGiorni <= 0);

                    var noleggio = new Noleggio(nomeCliente, modelloAuto, durataGiorni);
                    sistemaNoleggio.AggiungiNoleggio(noleggio);
                    break;

                case "2":
                    sistemaNoleggio.VisualizzaNoleggi();
                    break;

                case "3":
                    Console.Write("Inserisci il nome del cliente da cercare: ");
                    string nomeClienteDaCercare = Console.ReadLine();
                    sistemaNoleggio.CercaNoleggio(nomeClienteDaCercare);
                    break;

                case "4":
                    Console.Write("Inserisci il nome del cliente per modificare il noleggio: ");
                    string nomeClienteModifica = Console.ReadLine();

                    Console.Write("Inserisci la nuova durata del noleggio (in giorni): ");
                    if (int.TryParse(Console.ReadLine(), out int nuovaDurataGiorni))
                    {
                        sistemaNoleggio.ModificaDurataNoleggio(nomeClienteModifica, nuovaDurataGiorni);
                    }
                    else
                    {
                        Console.WriteLine("Durata non valida. Assicurati di inserire un numero intero.");
                    }
                    break;

                case "5":
                    Console.Write("Inserisci il nome del cliente per terminare il noleggio: ");
                    string nomeClienteTermina = Console.ReadLine();
                    sistemaNoleggio.TerminaNoleggio(nomeClienteTermina);
                    break;

                case "6":
                    sistemaNoleggio.SalvaNoleggi();
                    Console.WriteLine("Salvataggio ed uscita dal programma.");
                    return;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }

            Console.WriteLine(); // Linea vuota per leggibilità
        }
    }
}

