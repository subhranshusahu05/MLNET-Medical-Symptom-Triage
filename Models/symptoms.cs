using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMLNetModel.Models
{
    public class symptoms
    {
        public string PredictedLabel { get; set; } = null!;
        public float[] Score { get; set; } = null!;
    }
}
