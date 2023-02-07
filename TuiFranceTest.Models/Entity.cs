using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiFranceTest.Models
{
    /// <summary>
    /// Défini les propriétés et méthodes d'une entité.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Obtient ou définit l'identifiant technique de l'entité.
        /// </summary>
        int Id { get; set; }
    }
}
