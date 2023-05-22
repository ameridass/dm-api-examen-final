namespace dm_ef_api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public String nombre_curso { get; set; }
        public int semestre_curso { get; set; }
        public int creditos_curso { get; set; }
    }
}
