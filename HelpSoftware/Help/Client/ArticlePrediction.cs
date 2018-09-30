using Microsoft.ML.Runtime.Api;

namespace Help
{
  public class ArticlePrediction
  {
    [ColumnName("PredictedLabel")]
    public float PredictedLabels;
  }
}