using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MenuItem
    {
        /// <summary>
        /// id - DOM
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Выводимое имя 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// функция выполняемая пунктом при клике
        /// </summary>
        public string FunJs { get; set; }

        /// <summary>
        /// вложенные пункты 
        /// </summary>
        public List<MenuItem> Children {get; set;}

        /// <summary>
        /// Элемент без фунции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public MenuItem(string id, string name)
        {
            Id = id;
            Name = name;
            FunJs = null;
            Children = new List<MenuItem>();
        }

        /// <summary>
        /// Элемент с функцией
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="fun"></param>
        public MenuItem(string id, string name, string fun)
        {
            Id = id;
            Name = name;
            FunJs = fun;
            Children = new List<MenuItem>();
        }
    }
}