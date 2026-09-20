using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMLNetModel.Models
{
    public class symptomssData
    {
        [LoadColumn(1)]
        public string Content { get; set; } = null!;
        [LoadColumn(2)]
        public string Category { get; set; } = null!;
    }
}
