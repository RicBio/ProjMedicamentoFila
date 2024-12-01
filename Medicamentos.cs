using System.Collections.Generic;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos = new List<Medicamento>();

    public void Adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

    public bool Deletar(Medicamento medicamento)
    {
        if (medicamento.QtdeDisponivel() == 0)
        {
            return listaMedicamentos.Remove(medicamento);
        }
        return false;
    }

    public Medicamento Pesquisar(Medicamento medicamento)
    {
        return listaMedicamentos.Find(m => m.Equals(medicamento)) ?? new Medicamento();
    }

    public List<Medicamento> Listar()
    {
        return listaMedicamentos;
    }
}
