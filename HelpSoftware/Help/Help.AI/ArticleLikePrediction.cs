using Microsoft.ML.Runtime.Api;

namespace Help.AI
{
  public class ArticleLikePrediction
  {
    [ColumnName("Score")]
    public float[] PredictedLabels;
  }
}