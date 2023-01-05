using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmeansGUI
{
    //Первоначальная таблица данных
    class InputTable
    {
        private DataGridView DataGrid;

        public InputTable(DataGridView dataGrid)
        {
            DataGrid = dataGrid;
        }

        public void AddRow(params string[] coltext)
        {
            DataGrid.Rows.Add(coltext);
        }

        public void DefaultValues()
        {
            DataGrid.Rows.Clear();
            AddRow("Березники-Чусовская",           "376",  "904",   "Да",   "1985", "3");
            AddRow("Смычка-Егоршино",               "285",  "1032",  "Да",   "655",  "2");
            AddRow("Омск-Войновка",                 "136",  "844",   "Нет",  "3204", "2");
            AddRow("Алтайская-Курган",              "582",  "642",   "Нет",  "654",  "1");
            AddRow("Омск-Курган",                   "42",   "165",   "Нет",  "4510", "2");
            AddRow("Лянгасово-Нижний Новгород",     "390",  "640",   "Да",   "1645", "1");
            AddRow("Санкт-Петербург-Лянгасово",     "489",  "564",   "Нет",  "5413", "2");
            AddRow("Лянгасово-Пермь",               "376",  "846",   "Нет",  "584",  "2");
            AddRow("Пермь-Агрыз",                   "109",  "1002",  "Да",   "1534", "3");
            AddRow("Агрыз-Екатеринбург",            "110",  "455",   "Да",   "3520", "2");
            AddRow("Смычка-Гороблагодатская",       "143",  "1364",  "Нет",  "1104", "1");
            AddRow("Войновка-Богданович",           "122",  "99",    "Нет",  "1246", "2");
            AddRow("Орехово-Юдино",                 "316",  "961",   "Да",   "854",  "1");
            AddRow("Омск-Алтайская",                "262",  "156",   "Да",   "3510", "3");
            AddRow("Богданович-Каменск-Уральский",  "328",  "246",   "Нет",  "946",  "3");
            AddRow("Серов-Егоршино",                "561",  "1062",  "Да",   "1581", "2");
            AddRow("Челябинск-Каменск-Уральский",   "109",  "346",   "Да",   "796",  "3");
            AddRow("Серов-Гороблагодатская",        "161",  "964",   "Нет",  "776",  "1");

        }
    }
}
