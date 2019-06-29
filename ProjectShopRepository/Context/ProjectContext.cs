using ProjectShopRepository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShopRepository.Context
{
    internal class ProjectContext : DbContext
    {
        /// <summary>
        /// Конструктор наследника не делает ничего, кроме вызова базового класса с передачей строки подключения DBConnection
        /// </summary>
        public ProjectContext() : base("DBConnection")
        { }

        internal DbSet<User> Users { get; set; }
    }
}