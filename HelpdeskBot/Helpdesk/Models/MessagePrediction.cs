using Microsoft.ML.Data;

namespace ChamadoDataAccessLibrary.Models
{
    public class MessagePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedIntent { get; set; }

    }
}
