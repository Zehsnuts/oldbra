using System;
using System.IO;
using System.Xml;

namespace Bradesco
{
    public class BradescoInfo
    {
        private string versionApp;
        private string versionContent;

        private string vigenciaTarifaPFNew;
        private string vigenciaTarifaPFOld;

        private string vigenciaTarifaPJNew;
        private string vigenciaTarifaPJAOld;

        private string vigenciaTarifaPrimePFNew;
        private string vigenciaTarifaPrimePFOld;

        private string taxaJurosPFNew;
        private string taxaJurosPFOld;

        private string taxaJurosPJNew;
        private string taxaJurosPJOld;

        private string taxaJurosPrimePFNew;
        private string taxaJurosPrimePFOld;

        //-------------------------------------------------------------------------------
        public string VersionApp
        {
            get { return versionApp; }
            set { versionApp = value; }
        }
        public string VersionContent
        {
            get { return versionContent; }
            set { versionContent = value; }
        }

        //-------------------------------------------------------------------------------
        public string VigenciaTarifaPFNew
        {
            get { return vigenciaTarifaPFNew; }
            set { vigenciaTarifaPFNew = value; }
        }
        public string VigenciaTarifaPFOld
        {
            get { return vigenciaTarifaPFOld; }
            set { vigenciaTarifaPFOld = value; }
        }
        public string VigenciaTarifaPJNew
        {
            get { return vigenciaTarifaPJNew; }
            set { vigenciaTarifaPJNew = value; }
        }
        public string VigenciaTarifaPJOld
        {
            get { return vigenciaTarifaPJAOld; }
            set { vigenciaTarifaPJAOld = value; }
        }
        public string VigenciaTarifaPrimePFNew
        {
            get { return vigenciaTarifaPrimePFNew; }
            set { vigenciaTarifaPrimePFNew = value; }
        }
        public string VigenciaTarifaPrimePFOld
        {
            get { return vigenciaTarifaPrimePFOld; }
            set { vigenciaTarifaPrimePFOld = value; }
        }

        //-------------------------------------------------------------------------------
        public string VigenciaTarifaPFNewVerbose
        {
            get { return "A partir de " + vigenciaTarifaPFNew; }
        }
        public string VigenciaTarifaPFOldVerbose
        {
            get { return "De " + vigenciaTarifaPFOld; }
        }
        public string VigenciaTarifaPJNewVerbose
        {
            get { return "A partir de " + vigenciaTarifaPJNew; }
        }
        public string VigenciaTarifaPJOldVerbose
        {
            get { return "De " + vigenciaTarifaPJAOld; }
        }
        public string VigenciaTarifaPrimePFNewVerbose
        {
            get { return "A partir de " + vigenciaTarifaPrimePFNew; }
        }
        public string VigenciaTarifaPrimePFOldVerbose
        {
            get { return "De " + vigenciaTarifaPrimePFOld; }
        }

        //-------------------------------------------------------------------------------
        public string TaxaJurosPFNew
        {
            get { return taxaJurosPFNew; }
            set { taxaJurosPFNew = value; }
        }
        public string TaxaJurosPFOld
        {
            get { return taxaJurosPFOld; }
            set { taxaJurosPFOld = value; }
        }
        public string TaxaJurosPJNew
        {
            get { return taxaJurosPJNew; }
            set { taxaJurosPJNew = value; }
        }
        public string TaxaJurosPJOld
        {
            get { return taxaJurosPJOld; }
            set { taxaJurosPJOld = value; }
        }
        public string TaxaJurosPrimePFNew
        {
            get { return taxaJurosPrimePFNew; }
            set { taxaJurosPrimePFNew = value; }
        }
        public string TaxaJurosPrimePFOld
        {
            get { return taxaJurosPrimePFOld; }
            set { taxaJurosPrimePFOld = value; }
        }

        //-------------------------------------------------------------------------------
        public BradescoInfo(string xmlFile)
        {
            readConfXML(xmlFile);
        }

        //-------------------------------------------------------------------------------
        private void readConfXML(string xmlFile)
        {
            string xmlString;

            if (File.Exists(xmlFile))
            {
                xmlString = File.ReadAllText(xmlFile);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);

                XmlNodeList parametersNode = doc.DocumentElement.SelectNodes("/parameters/parameter");

                foreach (XmlNode paramNode in parametersNode)
                {
                    Console.WriteLine(paramNode.Attributes["name"].Value + " = " + paramNode.InnerText);
                    switch (paramNode.Attributes["name"].Value)
                    {
                        case "VersaoApp":
                            VersionApp = paramNode.InnerText;
                            break;
                        case "VersaoConteudo":
                            VersionContent = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPFNova":
                            VigenciaTarifaPFNew = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPFAntiga":
                            VigenciaTarifaPFOld = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPJNova":
                            VigenciaTarifaPJNew = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPJAntiga":
                            VigenciaTarifaPJOld = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPrimePFNova":
                            VigenciaTarifaPrimePFNew = paramNode.InnerText;
                            break;
                        case "VigenciaTarifaPrimePFAntiga":
                            VigenciaTarifaPrimePFOld = paramNode.InnerText;
                            break;
                        case "TaxaJurosPFNova":
                            TaxaJurosPFNew = paramNode.InnerText;
                            break;
                        case "TaxaJurosPFAntiga":
                            TaxaJurosPFOld = paramNode.InnerText;
                            break;
                        case "TaxaJurosPJNova":
                            TaxaJurosPJNew = paramNode.InnerText;
                            break;
                        case "TaxaJurosPJAntiga":
                            TaxaJurosPJOld = paramNode.InnerText;
                            break;
                        case "TaxaJurosPrimePFNova":
                            TaxaJurosPrimePFNew = paramNode.InnerText;
                            break;
                        case "TaxaJurosPrimePFAntiga":
                            TaxaJurosPrimePFOld = paramNode.InnerText;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Arquivo não encontrado: " + xmlFile);
            }
        }
    }
}
