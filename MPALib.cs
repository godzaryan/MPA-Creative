using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Sera
{
    class SeraDataReader
    {
        private string GetBetweenString(string TotalString, string FirstString, string LastString)
        {
            int num = TotalString.IndexOf(FirstString) + FirstString.Length;
            int num2 = TotalString.IndexOf(LastString);
            return TotalString.Substring(num, num2 - num);
        }

        public string GetData(string DataName, string FileName)
        {
            if (File.Exists(FileName))
            {
                string allData = File.ReadAllText(FileName);
                if (allData.Contains("<" + DataName + ">") && allData.Contains("</" + DataName + ">"))
                {
                    foreach (string curLine in allData.Split('\n'))
                    {
                        if (curLine.Contains("<" + DataName + ">") && curLine.Contains("</" + DataName + ">") && curLine.StartsWith("<" + DataName + ">") && curLine.EndsWith("</" + DataName + ">"))
                        {
                            string tempRem = curLine.Remove(0, DataName.Length + 2);
                            return tempRem.Remove((tempRem.Length - (DataName.Length + 3)), (DataName.Length + 3));
                        }
                        else
                        {
                            return null;
                        }    
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return null;
        }

        public void SetData(string DataName, string DataValue, string FileName)
        {
            if (File.Exists(FileName))
            {
                string allData = File.ReadAllText(FileName);
                if (allData.Contains("<" + DataName + ">") && allData.Contains("</" + DataName + ">"))
                {
                    allData = allData.Replace("<" + DataName + ">" + GetBetweenString(allData, "<" + DataName + ">", "</" + DataName + ">") + "</" + DataName + ">", "<" + DataName + ">" + DataValue + "</" + DataName + ">");
                    File.WriteAllText(FileName, allData);
                }
                else
                {
                    if (allData == "")
                    {
                        allData += "<" + DataName + ">" + DataValue + "</" + DataName + ">";
                    }
                    else
                    {
                        allData += "\n<" + DataName + ">" + DataValue + "</" + DataName + ">";
                    }
                    
                    File.WriteAllText(FileName, allData);
                }
            }
            else
            {
                File.WriteAllText(FileName, "<" + DataName + ">" + DataValue + "</" + DataName + ">");
            }
        }
    }
}
