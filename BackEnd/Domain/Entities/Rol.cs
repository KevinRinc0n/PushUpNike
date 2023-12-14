namespace Domain.Entities;

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<User> Usuarios { get; set; }  = new HashSet<User>();
    public ICollection<UserRol> RolesUsuarios { get; set; }
}