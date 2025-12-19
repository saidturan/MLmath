using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTranslatorWinForms.ML
{
    internal class TextPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }
    }
}
