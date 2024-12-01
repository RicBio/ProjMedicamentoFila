using System;

class Program
{
    static void Main(string[] args)
    {
        Medicamentos medicamentos = new Medicamentos();
        int opcao;

        do
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento");
            Console.WriteLine("6. Listar medicamentos");
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("ID do medicamento: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome do medicamento: ");
                    string nome = Console.ReadLine();
                    Console.Write("Laboratório: ");
                    string laboratorio = Console.ReadLine();
                    medicamentos.Adicionar(new Medicamento(id, nome, laboratorio));
                    break;

                case 2:
                    Console.Write("ID do medicamento: ");
                    id = int.Parse(Console.ReadLine());
                    Medicamento medSintetico = medicamentos.Pesquisar(new Medicamento { Id = id });
                    Console.WriteLine(medSintetico.ToString());
                    break;

                case 3:
                    Console.Write("ID do medicamento: ");
                    id = int.Parse(Console.ReadLine());
                    Medicamento medAnalitico = medicamentos.Pesquisar(new Medicamento { Id = id });
                    Console.WriteLine(medAnalitico.ToString());
                    foreach (var lote in medAnalitico.Lotes)
                    {
                        Console.WriteLine(lote.ToString());
                    }
                    break;

                case 4:
                    Console.Write("ID do medicamento: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("ID do lote: ");
                    int loteId = int.Parse(Console.ReadLine());
                    Console.Write("Quantidade: ");
                    int qtde = int.Parse(Console.ReadLine());
                    Console.Write("Data de vencimento (dd/mm/yyyy): ");
                    DateTime venc = DateTime.Parse(Console.ReadLine());
                    Medicamento medCompra = medicamentos.Pesquisar(new Medicamento { Id = id });
                    medCompra.Comprar(new Lote(loteId, qtde, venc));
                    break;

                case 5:
                    Console.Write("ID do medicamento: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Quantidade a vender: ");
                    qtde = int.Parse(Console.ReadLine());
                    Medicamento medVenda = medicamentos.Pesquisar(new Medicamento { Id = id });
                    if (medVenda.Vender(qtde))
                        Console.WriteLine("Venda realizada com sucesso!");
                    else
                        Console.WriteLine("Quantidade insuficiente para venda!");
                    break;

                case 6:
                    foreach (var med in medicamentos.Listar())
                    {
                        Console.WriteLine(med.ToString());
                    }
                    break;
            }
        } while (opcao != 0);
    }
}
