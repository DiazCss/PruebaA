namespace PruebaA.Models
{
    public class Autores
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public ICollection<Libros> Libros { get; set; }
    }
}
