using System;
using System.Collections.Generic;

public class Medicamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Laboratorio { get; set; }
    public Queue<Lote> Lotes { get; set; } = new Queue<Lote>();

    public Medicamento() { }

    public Medicamento(int id, string nome, string laboratorio)
    {
        Id = id;
        Nome = nome;
        Laboratorio = laboratorio;
    }

    public int QtdeDisponivel()
    {
        int total = 0;
        foreach (var lote in Lotes)
        {
            total += lote.Qtde;
        }
        return total;
    }

    public void Comprar(Lote lote)
    {
        Lotes.Enqueue(lote);
    }

    public bool Vender(int qtde)
    {
        if (qtde > QtdeDisponivel()) return false;

        while (qtde > 0 && Lotes.Count > 0)
        {
            var lote = Lotes.Peek();
            if (lote.Qtde <= qtde)
            {
                qtde -= lote.Qtde;
                Lotes.Dequeue();
            }
            else
            {
                lote.Qtde -= qtde;
                qtde = 0;
            }
        }
        return true;
    }

    public override string ToString()
    {
        return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Medicamento medicamento)
        {
            return Id == medicamento.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
