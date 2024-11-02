public class Noleggio
{
    public string NomeCliente { get; set; }
    public string ModelloAuto { get; set; }
    public int DurataGiorni { get; set; }
    public bool Attivo { get; set; } // Indica se il noleggio è attivo

    public Noleggio(string nomeCliente, string modelloAuto, int durataGiorni)
    {
        NomeCliente = nomeCliente;
        ModelloAuto = modelloAuto;
        DurataGiorni = durataGiorni;
        Attivo = true;
    }

    public void MostraDettagli()
    {
        Console.WriteLine($"Nome Cliente: {NomeCliente}");
        Console.WriteLine($"Modello Auto: {ModelloAuto}");
        Console.WriteLine($"Durata Giorni: {DurataGiorni}");
        Console.WriteLine($"Stato: {(Attivo ? "Attivo" : "Terminato")}");
        Console.WriteLine("-----------------------------");
    }
}
