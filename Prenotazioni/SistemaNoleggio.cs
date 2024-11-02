using System.Text.Json;

public class SistemaNoleggio
{
    private List<Noleggio> noleggi = new List<Noleggio>();
    private const string FilePath = "noleggi.json";

    public void AggiungiNoleggio(Noleggio noleggio)
    {
        var noleggioEsistente = noleggi.Find(n => n.NomeCliente.Equals(noleggio.NomeCliente, StringComparison.OrdinalIgnoreCase));
        
        if (noleggioEsistente != null)
        {
            Console.WriteLine("Noleggio già presente per questo nome cliente!");
        }
        else 
        {
            noleggi.Add(noleggio);
            Console.WriteLine("Noleggio aggiunto con successo!");
        }
    }

    public void VisualizzaNoleggi()
    {
        if (noleggi.Count == 0)
        {
            Console.WriteLine("Nessun noleggio presente.");
            return;
        }

        Console.WriteLine("Lista dei noleggi:");
        foreach (var noleggio in noleggi)
        {
            noleggio.MostraDettagli();
        }
    }
    public bool CercaNoleggio(string nomeCliente)
    {
        var noleggioTrovato = noleggi.Find(n => n.NomeCliente.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase) && n.Attivo);

        if (noleggioTrovato != null)
        {
            Console.WriteLine("Noleggio trovato:");
            noleggioTrovato.MostraDettagli();
            return true;
        }
        else
        {
            Console.WriteLine("Nessun noleggio attivo trovato per il cliente specificato.");
            return false;
        }
    }

    public void ModificaDurataNoleggio(string nomeCliente, int nuovaDurataGiorni)
    {
        var noleggioTrovato = noleggi.Find(n => n.NomeCliente.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase) && n.Attivo);

        if (noleggioTrovato != null)
        {
            noleggioTrovato.DurataGiorni = nuovaDurataGiorni;
            Console.WriteLine($"Durata del noleggio per {nomeCliente} aggiornata a {nuovaDurataGiorni} giorni.");
        }
        else
        {
            Console.WriteLine("Nessun noleggio attivo trovato per il cliente specificato.");
        }
    }

    public void TerminaNoleggio(string nomeCliente)
    {
        var noleggioTrovato = noleggi.Find(n => n.NomeCliente.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase) && n.Attivo);

        if (noleggioTrovato != null)
        {
            noleggioTrovato.Attivo = false;
            Console.WriteLine($"Noleggio per {nomeCliente} terminato correttamente!");
        }
        else
        {
            Console.WriteLine("Nessun noleggio trovato");
        }
    }
    public void SalvaNoleggi()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(noleggi, options);
        File.WriteAllText(FilePath, json);
        Console.WriteLine("Noleggi salvati su file!");
    }

    public void CaricaNoleggi()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            noleggi = JsonSerializer.Deserialize<List<Noleggio>>(json) ?? new List<Noleggio>();
            Console.WriteLine("Noleggi caricati correttamente!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Nessun file trovato, verrà creato un nuovo database di noleggi");
        }
    }

    public void VisualizzaStatistiche()
    {
        int totaleNoleggi = noleggi.Count();
        int noleggiAttivi = noleggi.Count(n => n.Attivo);
        int noleggiTerminati = totaleNoleggi - noleggiAttivi;

        //Percentuali
        double percentualeAttivi = totaleNoleggi > 0 ? (noleggiAttivi * 100.0) / totaleNoleggi : 0;
        double percentualeTerminati = totaleNoleggi > 0 ? (noleggiTerminati * 100.0) / totaleNoleggi : 0;

        // Durata media dei noleggi attivi
        double durataMediaAttivi = totaleNoleggi > 0
             ? noleggi.Where(n => n.Attivo).Average(n => n.DurataGiorni)
             : 0;

        Console.WriteLine("Statistiche sui noleggi:");
        Console.WriteLine($"- Numero totale di noleggi: {totaleNoleggi}");
        Console.WriteLine($"- Numero di noleggi attivi: {noleggiAttivi} ({percentualeAttivi:F2}%)");
        Console.WriteLine($"- Numero di noleggi terminati: {noleggiTerminati} ({percentualeTerminati:F2}%)");
        Console.WriteLine($"- Durata media dei noleggi attivi: {durataMediaAttivi:F2} giorni");
    }
}