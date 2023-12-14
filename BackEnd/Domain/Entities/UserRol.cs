namespace Domain.Entities;

public class UserRol
{
    public int Id { get; set; }
    public int IdUsuarioFk { get; set; }
    public User Usuario { get; set; }
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }
}