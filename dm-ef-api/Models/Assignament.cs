namespace dm_ef_api.Models
{
    public class Assignament
    {
        public int Id { get; set; }
        public int id_curso { get; set; }
        public int id_estudiante { get; set; }
        public String seccion_asignacion { get; set; }
        public DateTime fecha_realizacion { get; set; }
        public int semestre_asignacion { get; set; }
        public int año_asignacion { get; set; }
    }
}
