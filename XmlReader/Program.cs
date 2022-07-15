using System.Text;
using System.Xml;
using XmlReader;

const string dirPath = "..\\..\\..\\..\\Top"; //constant with the location of our directory
const string name = "EAN"; //constant with the keyword we're looking for
List<Product> products = new List<Product>();
StringBuilder outcome = new StringBuilder();

string[] allFilePaths = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
foreach (string filePath in allFilePaths)
{
    XmlNodeList nodeList = GetNodeList(filePath, name);
    foreach (XmlNode node in nodeList)
    {
        products.Add(new Product(node.InnerText));
        outcome.Append(node.InnerText + "\n");
    }
}

XmlNodeList GetNodeList(string wantedFilePath, string wantedName)
{
    string xmlFile = File.ReadAllText(wantedFilePath);
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.LoadXml(xmlFile);
    XmlNodeList nodeList = xmldoc.GetElementsByTagName(wantedName);
    return nodeList;
}

Console.Write(outcome.ToString());