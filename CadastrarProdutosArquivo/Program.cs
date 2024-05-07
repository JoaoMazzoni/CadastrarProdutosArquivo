
using CadastrarProdutosArquivo;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;

string path = @"C:\DadosEstoque\";
string file = "products.txt";

Console.WriteLine("---- CADASTRO DE PRODUTOS ----\n");

//List<Product> products = new List<Product>();

//products.Add(CreateProduct());
//ShowAll(products);

//products.Add(CreateProduct());
//ShowAll(products);

//SaveFile(products, path, file);

List<Product> products2 = new(LoadFile(path, file));

ShowAll(products2);

Product CreateProduct()
{
    Console.Write("Informe o ID: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("\nInforme a descrição do produto: ");
    string description = Console.ReadLine();

    Console.Write("\nInforme o preço do produto: ");
    double price = double.Parse(Console.ReadLine());

    Console.Write("\nInforme a quantidade disponível: ");
    int qtd = int.Parse(Console.ReadLine());

    return new Product(id, description, price, qtd);
}

void ShowAll(List<Product> recievedList)
{
    foreach (Product product in recievedList)
    {
        Console.WriteLine(product.ToString());
    }

}

bool CheckIfExists(string path, string file)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    if (!File.Exists(path + file))
    {
        File.Create(path + file);
    }

    return true;
}


void SaveFile(List<Product> lista, string path, string file)
{
    if (CheckIfExists(path, file))
    {
        StreamWriter sw = new(path + file);

        foreach (Product item in lista)
        {
            sw.WriteLine(item.ToString());
        }
        sw.Close();
    }
}

List<Product> LoadFile(string path, string file)
{

    List<Product> list = new List<Product>();
    if (CheckIfExists(path, file))
    {
        StreamReader sr = new(path + file);
        string[] data = new string[4];


        foreach (var linha in File.ReadAllLines(path + file)) //Lê todas as linhas do file, retorna cada linha.
        {
            data = linha.Split(";"); //Cada string da linha delimitada(Split) por ";" será guardada no vetor data que possui as 4 posições necessárias para cada uma 
            list.Add(new Product(int.Parse(data[0]), data[1], double.Parse(data[2]), int.Parse(data[3]))); //Cria um novo produto usando os dados do vetor data

        }

    }

    return list;

}


