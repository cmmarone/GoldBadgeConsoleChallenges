using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMethods
{
    public static class TableMethods
    {
        public static string GenerateCell(string data, string typeOfData, int columnWidth)
        {
            if (typeOfData == "text")
            {
                StringBuilder buffer = new StringBuilder();
                for (int i = 1; i < (columnWidth - data.Length); i++)
                {
                    buffer.Append(" ");
                }
                string textCell = $" {data}{buffer}";
                return textCell;
            }
            if (typeOfData == "number")
            {
                StringBuilder buffer = new StringBuilder();
                for (int i = 1; i < (columnWidth - data.Length); i++)
                {
                    buffer.Append(" ");
                }
                string numberCell = $"{buffer}{data} ";
                return numberCell;
            }
            if (typeOfData == "money")
            {
                StringBuilder buffer = new StringBuilder();
                for (int i = 1; i < ((columnWidth - data.Length) - 1); i++)
                {
                    buffer.Append(" ");
                }
                string moneyCell = $"{buffer}${data} ";
                return moneyCell;
            }
            else
            {
                return "error";
            }
        }
    }
}
