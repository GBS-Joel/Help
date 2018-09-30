using System.Collections.Generic;

namespace Help.AI
{
  public interface IDataLoader<T>
  {
    List<T> LoadDataForPrediction(object Parameter);

    List<T> LoadDataForEvaluate(object Paramter);

    void StoreData();
  }
}