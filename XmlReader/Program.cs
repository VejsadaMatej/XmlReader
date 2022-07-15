using System.Text;
using System.Xml;
using XmlReader;

const string dirPath = "..\\..\\..\\..\\Top"; //constant with the location of our directory
List<Product> products = new List<Product>();
StringBuilder outcome = new StringBuilder();

string[] allFilePaths = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
foreach (string filePath in allFilePaths)
{
    string xmlFile = File.ReadAllText(filePath);
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.LoadXml(xmlFile);
    XmlNodeList nodeList = xmldoc.GetElementsByTagName("EAN");
    foreach (XmlNode node in nodeList)
    {
        products.Add(new Product(node.InnerText));
        outcome.Append(node.InnerText + "\n");
    }
}

foreach (Product product in products)
{
    Console.WriteLine(product);
}