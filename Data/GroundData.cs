using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Admin
{
    class GroundData
    {
        private string[][] personalDataGenerated = {

            new string[] { "Иван", "Олег", "Анна", "Андрей", "Марина", "Сергей", "Владислав", "Маргарита", "Александр", "Юлия"},
            new string[] { "Петров", "Иванов", "Шмидт", "Кузнецов", "Ярвинен", "Ковальский", "Иванчук", "Швец", "Джонсон", "Фейн" },
            new string[] { "Федорович", "Петрович", "Вильгельмович", "Иванович", "Туомасович", "Александрович", "Андреевич", "Оскарович", "Рудольфович", "Игоревич" }
        };

        public string[][] GetGroundData()
        {
            return personalDataGenerated;
        }
    }
}
