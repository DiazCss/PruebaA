using System.ComponentModel.DataAnnotations;

namespace PruebaA.Models
{
    public class Libros
    {
        public int Id { get; set; }
        [Required]  
        public int? AutorId { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public int Edicion { get; set; }
        public string Clasificacion {  get; set; }
        public DateOnly AnyoPublicacion { get; set; }


        public Autores autores { get; set; }
    }
}
