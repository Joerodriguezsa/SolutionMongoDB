namespace Annarth.Domain.Entities
{
    public class Company
    {
        /// <summary>
        /// Id Company
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
