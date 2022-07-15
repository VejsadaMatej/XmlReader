using System.Xml;
using XmlReader;

const string dirPath = "..\\..\\..\\..\\Top"; //constant with the location of our directory
List<Product> products = new List<Product>();
string ean;

string[] allFilePaths = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
foreach (string filePath in allFilePaths)
{
    string xmlFile = File.ReadAllText(filePath);
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.LoadXml(xmlFile);
    XmlNodeList nodeList = xmldoc.GetElementsByTagName("EAN");
    foreach (XmlNode node in nodeList)
    {
        ean = node.InnerText;
        products.Add(new Product(ean));
    }
}

foreach (Product product in products)
{
    Console.WriteLine(product);
}