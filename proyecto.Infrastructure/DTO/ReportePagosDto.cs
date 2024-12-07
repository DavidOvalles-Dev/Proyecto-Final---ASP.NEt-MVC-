using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Application.DTOs
{
    public class ReportePagosDto
    {
        public int MiembroId { get; set; }
        public string NombreCompleto { get; set; }
        public decimal TotalPagado { get; set; }
    }
}

