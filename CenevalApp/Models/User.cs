namespace CenevalApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        // Aun no se hashea ya que es una prueba de concepto, pero en producción esto debe ser un hash seguro
        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = "Alejandro Chacin";

        public UserProgress? Progress { get; set; }
    }
}