using ArticuloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticuloApi.Data
{
    public class Contexto: DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Contexto(DbContextOptions<Contexto> options) : base(options)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

        }
    }
}
