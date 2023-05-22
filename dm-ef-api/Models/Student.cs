namespace dm_ef_api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public String nombre_estudiante { get; set; }
        public String carne_estudiante { set; get; }
        public String carrera_estudiante { set; get; }
        public String correo_estudiante { set; get; }
        public String telefono_estudiante { set; get; }
        public String genero_estudiante { set; get; }
        public DateTime fecha_ingreso { get; set; }
    }
}
