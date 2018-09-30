using Microsoft.ML.Runtime.Api;

namespace Help
{
  public class ArticleData
  {
    [Column("0")]
    public string ArticlePreview;

    [Column("1")]
    public string ArticleTitle;

    [Column("2")]
    public string Tag1;

    [Column("3")]
    public string Tag2;

    [Column("4")]
    public string Topic1;

    [Column("5")]
    public string Topic2;

    [Column("6")]
    public string Created;

    [Column("7")]
    [ColumnName("Label")]
    public float Label;
  }
}