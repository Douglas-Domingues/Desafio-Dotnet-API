using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;
using StartUp;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options)
            : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }


}