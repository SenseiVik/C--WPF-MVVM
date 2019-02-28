using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public static class LanguageManager
    {
        public static Dictionary<string, string> GetDictionaryEnglish()
        {
            return new Dictionary<string, string>()
            {
                ["more"] = "More",
                ["sort"] = "Sort",
                ["title"] = "Title",
                ["volume"] = "Volume",
                ["color"] = "Color",
                ["year"] = "Year",
                ["price"] = "Price",
                ["transmission"] = "Transmission",
                ["drive"] = "Drive",
                ["body"] = "Body",
                ["close"] = "Hide",
                ["append"] = "Append",
                ["edit"] = "Edit",
                ["remove"] = "Remove",
                ["view"] = "View"
            };
        }

        public static Dictionary<string, string> GetDictionaryRussian()
        {
            return new Dictionary<string, string>()
            {
                ["more"] = "Подробнее",
                ["sort"] = "Сортировать",
                ["title"] = "Название",
                ["volume"] = "Обьем двигателя",
                ["color"] = "Цвет",
                ["year"] = "Год",
                ["price"] = "Цена",
                ["transmission"] = "Коробка передач",
                ["drive"] = "Привод",
                ["body"] = "Кузов",
                ["close"] = "Свернуть",
                ["append"] = "Добавить",
                ["edit"] = "Редактировать",
                ["remove"] = "Удалить",
                ["view"] = "Просмотр"
            };
        }
    }
}
